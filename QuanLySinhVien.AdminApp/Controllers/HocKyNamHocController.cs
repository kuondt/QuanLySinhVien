using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QuanLySinhVien.AdminApp.Services.HocKyNamHoc;
using QuanLySinhVien.AdminApp.Services.SinhVien;
using QuanLySinhVien.ViewModel.Catalog.HocKyNamHocs;

namespace QuanLySinhVien.AdminApp.Controllers
{
    public class HocKyNamHocController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IHocKyNamHocApiClient _hocKyNamHocApiClient;

        public HocKyNamHocController(IConfiguration configuration, IHocKyNamHocApiClient hocKyNamHocApiClient)
        {
            _configuration = configuration;
            _hocKyNamHocApiClient = hocKyNamHocApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 9)
        {
            var request = new HocKyNamHocManagePagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _hocKyNamHocApiClient.GetAllPaging(request);

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
        public async Task<IActionResult> Create([FromForm] HocKyNamHocCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            //Lặp 3 lần tạo 3 học kỳ
            for (int i = 1; i <= 3; i++)
            {
                request.HocKy = i;
                request.NgayBatDau = new DateTime(request.NamHoc, 1, 1);
                request.NgayKetThuc = new DateTime(request.NamHoc, 1, 1);

                var result = await _hocKyNamHocApiClient.Create(request);

                if (result)
                {
                    TempData["result"] = "Thêm mới thành công";
                }
            }

            if (TempData["result"] != null)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm mới thất bại");
            return View(request);
        }

        [HttpGet("HocKyNamHoc/{hocky}/{namhoc}")]
        public async Task<IActionResult> Edit(int hocky, int namhoc)
        {
            var hocKyNamHoc = await _hocKyNamHocApiClient.GetById(hocky, namhoc);

            if (hocKyNamHoc != null)
            {
                var updateRequest = new HocKyNamHocUpdateRequest()
                {
                    HocKy = hocKyNamHoc.HocKy,
                    NamHoc = hocKyNamHoc.NamHoc,
                    NgayBatDau = hocKyNamHoc.NgayBatDau,
                    NgayKetThuc = hocKyNamHoc.NgayKetThuc
                };
                return View(updateRequest);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost("HocKyNamHoc/{hocky}/{namhoc}")]
        public async Task<IActionResult> Edit(int hocky, int namhoc, HocKyNamHocUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _hocKyNamHocApiClient.Update(hocky, namhoc, request);
            if (result)
            {
                TempData["result"] = "Cập nhật thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Cập nhật không thành công");
            return View(request);
        }

        //[HttpGet("HocKyNamHoc/{hocky}/{namhoc}")]
        //public async Task<IActionResult> Details(int hocky, int namhoc)
        //{
        //    var hocKyNamHoc = await _hocKyNamHocApiClient.GetById(hocky, namhoc);
        //    if (hocKyNamHoc != null)
        //    {
        //        var monHocViewModel = new HocKyNamHocViewModel()
        //        {
        //            HocKy = hocKyNamHoc.HocKy,
        //            NamHoc = hocKyNamHoc.NamHoc,
        //            NgayBatDau = hocKyNamHoc.NgayBatDau,
        //            NgayKetThuc = hocKyNamHoc.NgayKetThuc
        //        };
        //        return View(monHocViewModel);
        //    }
        //    return RedirectToAction("Error", "Home");
        //}
    }
}
