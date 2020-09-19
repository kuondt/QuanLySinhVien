using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QuanLySinhVien.AdminApp.Services.LopHocPhan;
using QuanLySinhVien.AdminApp.Services.MonHoc;
using QuanLySinhVien.AdminApp.Services.Phong;
using QuanLySinhVien.ViewModel.Catalog.LopHocPhans;
using QuanLySinhVien.ViewModel.Catalog.MonHocs;
using QuanLySinhVien.ViewModel.Catalog.Phongs;

namespace QuanLySinhVien.AdminApp.Controllers
{
    public class LopHocPhanController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly ILopHocPhanApiClient _lopHocPhanApiClient;
        private readonly IPhongApiClient _phongApiClient;
        private readonly IMonHocApiClient _monHocApiClient;

        public LopHocPhanController(IConfiguration configuration, ILopHocPhanApiClient lopHocPhanApiClient, IPhongApiClient phongApiClient, IMonHocApiClient monHocApiClient)
        {
            _configuration = configuration;
            _lopHocPhanApiClient = lopHocPhanApiClient;
            _phongApiClient = phongApiClient;
            _monHocApiClient = monHocApiClient;
        }

        public async Task<IActionResult> Index(int hocKy, int namHoc, int pageIndex = 1, int pageSize = 1000)
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMessage = TempData["result"];
            }

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

            var requestRoom = new PhongManagePagingRequest()
            {
                PageIndex = 1,
                PageSize = 1000
            };
            var rooms = await _phongApiClient.GetAllPaging(requestRoom);
            int RoomCount = rooms.Items.Count();
            ViewBag.RoomCount = RoomCount;

            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int hocky, int namhoc)
        {
            var lopHocPhanCreateRequest = new LopHocPhanCreateRequest()
            {
                HK_HocKy = hocky,
                HK_NamHoc = namhoc
            };
            return View(lopHocPhanCreateRequest);
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
                return RedirectToAction("Index", new { HocKy = request.HK_HocKy, NamHoc = request.HK_NamHoc });
            }

            ModelState.AddModelError("", "Thêm mới thất bại");
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Schedule(ScheduleRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _lopHocPhanApiClient.Schedule(request);
            if (result)
            {
                TempData["result"] = "Cập nhật thành công";
                return RedirectToAction("Index", new { HocKy = request.HocKy, NamHoc = request.NamHoc });
            }

            ModelState.AddModelError("", "Cập nhật không thành công");

            return RedirectToAction("Index", new { HocKy = request.HocKy, NamHoc = request.NamHoc });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var lopHocPhan = await _lopHocPhanApiClient.GetById(id);

            var updateRequest = new LopHocPhanUpdateRequest()
            {
                HK_HocKy = lopHocPhan.HK_HocKy,
                HK_NamHoc = lopHocPhan.HK_NamHoc,
                ID_GiangVien = lopHocPhan.ID_GiangVien,
                ID_MonHoc = lopHocPhan.ID_MonHoc,
                ID_Phong = lopHocPhan.ID_Phong,
                BuoiHoc = lopHocPhan.BuoiHoc,
                NgayHoc = lopHocPhan.NgayHoc                
            };
            return View(updateRequest);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, LopHocPhanUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _lopHocPhanApiClient.Update(id, request);
            if (result)
            {
                TempData["result"] = "Cập nhật thành công";
                return RedirectToAction("Index", new { HocKy = request.HK_HocKy, NamHoc = request.HK_NamHoc });
            }

            ModelState.AddModelError("", "Cập nhật không thành công");
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, LopHocPhanDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _lopHocPhanApiClient.Delete(id);
            if (result)
            {
                TempData["result"] = $"Xóa thành công lớp {id}";
                return RedirectToAction("Index", new { HocKy = request.HocKy, NamHoc = request.NamHoc });
            }

            ModelState.AddModelError("", "Xóa không thành công lớp {id}");
            return RedirectToAction("Index", new { HocKy = request.HocKy, NamHoc = request.NamHoc });
        }
    }
}
