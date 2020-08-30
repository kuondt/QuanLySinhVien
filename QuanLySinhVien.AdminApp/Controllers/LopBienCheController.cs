using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QuanLySinhVien.AdminApp.Services.LopBienChe;
using QuanLySinhVien.ViewModel.Catalog.LopBienChe;

namespace QuanLySinhVien.AdminApp.Controllers
{
    public class LopBienCheController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly ILopBienCheApiClient _lopBienCheApiClient;

        public LopBienCheController(IConfiguration configuration, ILopBienCheApiClient lopBienCheApiClient)
        {
            _lopBienCheApiClient = lopBienCheApiClient;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 3)
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
        public IActionResult Create()
        {
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
    }
}
