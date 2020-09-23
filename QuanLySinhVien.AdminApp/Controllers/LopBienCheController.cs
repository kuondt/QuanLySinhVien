using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QuanLySinhVien.AdminApp.Services.GiangVien;
using QuanLySinhVien.AdminApp.Services.LopBienChe;
using QuanLySinhVien.ViewModel.Catalog.GiangViens;
using QuanLySinhVien.ViewModel.Catalog.LopBienChes;

namespace QuanLySinhVien.AdminApp.Controllers
{
    public class LopBienCheController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly ILopBienCheApiClient _lopBienCheApiClient;
        private readonly IGiangVienApiClient _giangVienApiClient;

        public LopBienCheController(IConfiguration configuration, ILopBienCheApiClient lopBienCheApiClient, IGiangVienApiClient giangVienApiClient)
        {
            _lopBienCheApiClient = lopBienCheApiClient;
            _configuration = configuration;
            _giangVienApiClient = giangVienApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var request = new LopBienCheManagePagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _lopBienCheApiClient.GetAllPaging(request);

            ViewBag.Keyword = keyword;

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMessage = TempData["result"];
            }

            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> CreateAsync()
        {
            //Get list giang vien
            var requestGiangVien = new GiangVienManagePagingRequest()
            {
                PageIndex = 1,
                PageSize = 100
            };
            var giangViens = await _giangVienApiClient.GetAllPaging(requestGiangVien);
            ViewBag.giangViens = giangViens.Items;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] LopBienCheCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _lopBienCheApiClient.Create(request);
            if (result)
            {
                TempData["result"] = "Thêm mới thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm mới thất bại");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var lopBienChe = await _lopBienCheApiClient.GetById(id);
            if (lopBienChe != null)
            {
                var monHocViewModel = new LopBienCheViewModel()
                {
                    ID = lopBienChe.ID,
                    NamBatDau = lopBienChe.NamBatDau,
                    NamKetThuc = lopBienChe.NamKetThuc,
                    ID_Khoa = lopBienChe.ID_Khoa,
                    ID_GiangVien = lopBienChe.ID_GiangVien,
                    GiangVien = lopBienChe.GiangVien,
                    SinhViens = lopBienChe.SinhViens
                };
                return View(monHocViewModel);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var lopBienChe = await _lopBienCheApiClient.GetById(id);

            //Get list giang vien
            var requestGiangVien = new GiangVienManagePagingRequest()
            {
                PageIndex = 1,
                PageSize = 100
            };
            var giangViens = await _giangVienApiClient.GetAllPaging(requestGiangVien);
            ViewBag.giangViens = giangViens.Items;

            if (lopBienChe != null)
            {
                var updateRequest = new LopBienCheUpdateRequest()
                {
                    ID_GiangVien = lopBienChe.ID_GiangVien
                };
                return View(updateRequest);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, LopBienCheUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View();        

            var result = await _lopBienCheApiClient.Update(id, request);
            if (result)
            {
                TempData["result"] = "Cập nhật thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Cập nhật không thành công");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var lopBienChe = await _lopBienCheApiClient.GetById(id);

            if (lopBienChe != null)
            {
                var updateRequest = new LopBienCheUpdateRequest()
                {
                    ID = lopBienChe.ID
                };
                return View(updateRequest);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, LopBienCheUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _lopBienCheApiClient.Delete(id);
            if (result)
            {
                TempData["result"] = "Xóa thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Xóa không thành công");
            return View(request);
        }
    }
}
