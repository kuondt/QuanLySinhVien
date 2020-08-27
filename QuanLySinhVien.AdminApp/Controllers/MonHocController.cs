using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QuanLySinhVien.AdminApp.Services;
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

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 3)
        {
            var request = new MonHoc_ManagePagingRequest()
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
        public async Task<IActionResult> Create([FromForm] MonHoc_CreateRequest request)
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
    }
}
