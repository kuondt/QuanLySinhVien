﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QuanLySinhVien.AdminApp.Services.GiangVien;
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

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 3)
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
    }
}