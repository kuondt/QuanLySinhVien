using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QuanLySinhVien.AdminApp.Services.SinhVien;
using QuanLySinhVien.ViewModel.Catalog.SinhViens;

namespace QuanLySinhVien.AdminApp.Controllers
{
    public class SinhVienController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly ISinhVienApiClient _sinhVienApiClient;

        public SinhVienController(IConfiguration configuration, ISinhVienApiClient sinhVienApiClient)
        {
            _sinhVienApiClient = sinhVienApiClient;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 3)
        {
            var request = new SinhVienManagePagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _sinhVienApiClient.GetAllPaging(request);

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
        public async Task<IActionResult> Create([FromForm] SinhVienCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _sinhVienApiClient.Create(request);
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
            var sinhVien = await _sinhVienApiClient.GetById(id);

            if (sinhVien != null)
            {
                var updateRequest = new SinhVienUpdateRequest()
                {
                    Ho = sinhVien.Ho,
                    Ten = sinhVien.Ten,
                    DiaChi = sinhVien.DiaChi,
                    Email = sinhVien.Email,
                    SoDienThoai = sinhVien.SoDienThoai,
                    GioiTinh = sinhVien.GioiTinh,
                    NgaySinh = sinhVien.NgaySinh,
                    IsActive = sinhVien.IsActive,
                    ID_LopBienChe = sinhVien.ID_LopBienChe,
                    Nam = sinhVien.Nam,
        
                };
                return View(updateRequest);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, SinhVienUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _sinhVienApiClient.Update(id, request);
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
            var sinhVien = await _sinhVienApiClient.GetById(id);
            if (sinhVien != null)
            {
                var monHocViewModel = new SinhVienViewModel()
                {
                    ID = sinhVien.ID,
                    Ho = sinhVien.Ho,
                    Ten = sinhVien.Ten,
                    HoTen = sinhVien.HoTen,
                    DiaChi = sinhVien.DiaChi,
                    Email = sinhVien.Email,
                    SoDienThoai = sinhVien.SoDienThoai,
                    GioiTinh = sinhVien.GioiTinh,
                    NgaySinh = sinhVien.NgaySinh,
                    IsActive = sinhVien.IsActive,
                    ID_LopBienChe = sinhVien.ID_LopBienChe,
                    Nam = sinhVien.Nam,
                    
                };
                return View(monHocViewModel);
            }
            return RedirectToAction("Error", "Home");
        }
    }
}
