using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QuanLySinhVien.AdminApp.Services.MonHoc;
using QuanLySinhVien.ViewModel.Catalog.MonHocs;

namespace QuanLySinhVien.AdminApp.Controllers
{
    public class MonHocController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IMonHocApiClient _monHocApiClient;

        public MonHocController(IConfiguration configuration, IMonHocApiClient monHocApiClient)
        {
            _monHocApiClient = monHocApiClient;
            _configuration = configuration;

        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var request = new MonHocManagePagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _monHocApiClient.GetAllPaging(request);

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
        public async Task<IActionResult> Create([FromForm] MonHocCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _monHocApiClient.Create(request);
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
            var monHoc = await _monHocApiClient.GetById(id);
            if (monHoc != null)
            {
                var updateRequest = new MonHocUpdateRequest()
                {
                    ID = monHoc.ID,
                    TenMonHoc = monHoc.TenMonHoc,
                    SoTinChi = monHoc.SoTinChi
                };
                return View(updateRequest);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, MonHocUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _monHocApiClient.Update(id, request);
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
            var monHoc = await _monHocApiClient.GetById(id);
            if (monHoc != null)
            {
                var monHocViewModel = new MonHocViewModel()
                {
                    ID = monHoc.ID,
                    TenMonHoc = monHoc.TenMonHoc,
                    SoTiet = monHoc.SoTiet,
                    SoTinChi = monHoc.SoTinChi
                };
                return View(monHocViewModel);
            }
            return RedirectToAction("Error", "Home");
        }

    }
}
