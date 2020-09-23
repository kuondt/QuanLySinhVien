using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QuanLySinhVien.AdminApp.Services.GiangVien;
using QuanLySinhVien.Data.Enums;
using QuanLySinhVien.ViewModel.Catalog.GiangViens;

namespace QuanLySinhVien.AdminApp.Controllers
{
    public class GiangVienController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IGiangVienApiClient _giangVienApiClient;

        public GiangVienController(IConfiguration configuration, IGiangVienApiClient giangVienApiClient)
        {
            _giangVienApiClient = giangVienApiClient;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var request = new GiangVienManagePagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _giangVienApiClient.GetAllPaging(request);

            ViewBag.Keyword = keyword;

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMessage = TempData["result"];
            }

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] GiangVienCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _giangVienApiClient.Create(request);
            if (result)
            {
                TempData["result"] = "Thêm mới thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm mới thất bại");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var giangVien = await _giangVienApiClient.GetById(id);

            if (giangVien != null)
            {
                var updateRequest = new GiangVienUpdateRequest()
                {
                    Ho = giangVien.Ho,
                    Ten = giangVien.Ten,
                    DiaChi = giangVien.DiaChi,
                    Email = giangVien.Email,
                    SoDienThoai = giangVien.SoDienThoai,
                    GioiTinh = giangVien.GioiTinh,
                    NgaySinh = giangVien.NgaySinh,
                    IsActive = giangVien.IsActive
                };
                return View(updateRequest);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, GiangVienUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _giangVienApiClient.Update(id, request);
            if (result)
            {
                TempData["result"] = "Cập nhật thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Cập nhật không thành công");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var giangVien = await _giangVienApiClient.GetById(id);
            if (giangVien != null)
            {
                var monHocViewModel = new GiangVienViewModel()
                {
                    ID = giangVien.ID,
                    Ho = giangVien.Ho,
                    Ten = giangVien.Ten,
                    HoTen = giangVien.HoTen,
                    DiaChi = giangVien.DiaChi,
                    Email = giangVien.Email,
                    SoDienThoai = giangVien.SoDienThoai,
                    GioiTinh = giangVien.GioiTinh,
                    NgaySinh = giangVien.NgaySinh,
                    IsActive = giangVien.IsActive
                };
                return View(monHocViewModel);
            }
            return RedirectToAction("Error", "Home");
        }
    }
}
