using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QuanLySinhVien.AdminApp.Services.Phong;
using QuanLySinhVien.ViewModel.Catalog.Phongs;

namespace QuanLySinhVien.AdminApp.Controllers
{
    public class PhongController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IPhongApiClient _phongApiClient;

        public PhongController(IConfiguration configuration, IPhongApiClient phongApiClient)
        {
            _phongApiClient = phongApiClient;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var request = new PhongManagePagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _phongApiClient.GetAllPaging(request);

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
        public async Task<IActionResult> Create([FromForm] PhongCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _phongApiClient.Create(request);
            if (result)
            {
                TempData["result"] = "Thêm mới thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm mới thất bại");
            return View(request);
        }

        //[HttpGet]
        //public async Task<IActionResult> Edit(string id)
        //{
        //    var phong = await _phongApiClient.GetById(id);

        //    if (phong != null)
        //    {
        //        var updateRequest = new PhongUpdateRequest()
        //        {
        //            TenCoSo = phong.TenCoSo
        //        };
        //        return View(updateRequest);
        //    }
        //    return RedirectToAction("Error", "Home");
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(string id, PhongUpdateRequest request)
        //{
        //    if (!ModelState.IsValid)
        //        return View();

        //    var result = await _phongApiClient.Update(id, request);
        //    if (result)
        //    {
        //        TempData["result"] = "Cập nhật thành công";
        //        return RedirectToAction("Index");
        //    }

        //    ModelState.AddModelError("", "Cập nhật không thành công");
        //    return View(request);
        //}

        //[HttpGet]
        //public async Task<IActionResult> Details(string id)
        //{
        //    var phong = await _phongApiClient.GetById(id);
        //    if (phong != null)
        //    {
        //        var monHocViewModel = new PhongViewModel()
        //        {
        //            ID = phong.ID,
        //            TenCoSo = phong.TenCoSo
        //        };
        //        return View(monHocViewModel);
        //    }
        //    return RedirectToAction("Error", "Home");
        //}
    }
}
