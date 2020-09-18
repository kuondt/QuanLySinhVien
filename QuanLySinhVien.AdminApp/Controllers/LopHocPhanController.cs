using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QuanLySinhVien.AdminApp.Services.LopHocPhan;
using QuanLySinhVien.ViewModel.Catalog.LopHocPhans;

namespace QuanLySinhVien.AdminApp.Controllers
{
    public class LopHocPhanController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly ILopHocPhanApiClient _lopHocPhanApiClient;

        public LopHocPhanController(IConfiguration configuration, ILopHocPhanApiClient lopHocPhanApiClient)
        {
            _configuration = configuration;           
            _lopHocPhanApiClient = lopHocPhanApiClient;
        }

        public async Task<IActionResult> Index(int hocKy, int namHoc, int pageIndex = 1, int pageSize = 100)
        {
            var request = new LopHocPhanManagePagingRequest()
            {
                HocKy = hocKy,
                NamHoc = namHoc,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _lopHocPhanApiClient.GetSchedule(request);

            ViewBag.HocKy = hocKy;
            ViewBag.NamHoc = namHoc;

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMessage = TempData["result"];
            }

            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] LopHocPhanCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _lopHocPhanApiClient.Create(request);
            if (result)
            {
                TempData["result"] = "Thêm mới thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm mới thất bại");
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ScheduleRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _lopHocPhanApiClient.Schedule(request);
            if (result)
            {
                TempData["result"] = "Cập nhật thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Cập nhật không thành công");
            return View(request);
        }
    }
}
