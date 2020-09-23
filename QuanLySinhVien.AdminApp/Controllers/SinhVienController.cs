using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QuanLySinhVien.AdminApp.Services.ChuongTrinhDaoTao;
using QuanLySinhVien.AdminApp.Services.LopBienChe;
using QuanLySinhVien.AdminApp.Services.SinhVien;
using QuanLySinhVien.ViewModel.Catalog.ChuongTrinhDaoTaos;
using QuanLySinhVien.ViewModel.Catalog.LopBienChes;
using QuanLySinhVien.ViewModel.Catalog.SinhViens;

namespace QuanLySinhVien.AdminApp.Controllers
{
    public class SinhVienController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly ISinhVienApiClient _sinhVienApiClient;
        private readonly ILopBienCheApiClient _lopBienCheApiClient;
        private readonly IChuongTrinhDaoTaoApiClient _chuongTrinhDaoTaoApiClient;

        public SinhVienController(IConfiguration configuration, ISinhVienApiClient sinhVienApiClient, ILopBienCheApiClient lopBienCheApiClient, IChuongTrinhDaoTaoApiClient chuongTrinhDaoTaoApiClient)
        {
            _sinhVienApiClient = sinhVienApiClient;
            _configuration = configuration;
            _lopBienCheApiClient = lopBienCheApiClient;
            _chuongTrinhDaoTaoApiClient = chuongTrinhDaoTaoApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
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
        public async Task<IActionResult> Create()
        {
            //Lấy năm hiện tại
            string year = DateTime.Now.Year.ToString();
            //Lấy 2 số cuối của năm
            string lastTwoDigitsOfYear = year.Substring(year.Length - 2);

            //Get list giang vien
            var requestLopBienChe = new LopBienCheManagePagingRequest()
            {
                Keyword = lastTwoDigitsOfYear,
                PageIndex = 1,
                PageSize = 100
            };

            var lopBienChes = await _lopBienCheApiClient.GetAllPaging(requestLopBienChe);
            ViewBag.lopBienChes = lopBienChes.Items;

            //Lấy danh sách ctdt trùng với khóa của sinh viên
            var requestCTDT = new ChuongTrinhDaoTaoPagingRequest()
            {
                Keyword = year,
                PageIndex = 1,
                PageSize = 100
            };
            var chuonTrinhDaoTaos = await _chuongTrinhDaoTaoApiClient.GetAllPaging(requestCTDT);
            ViewBag.chuongTrinhDaoTaos = chuonTrinhDaoTaos.Items;

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

            //Lấy năm của sv
            string year = sinhVien.Nam.ToString();
            //Lấy 2 số cuối của năm
            string lastTwoDigitsOfYear = year.Substring(year.Length - 2);

            //Lấy danh sách lớp biên chế
            var requestLopBienChe = new LopBienCheManagePagingRequest()
            {
                Keyword = lastTwoDigitsOfYear,
                PageIndex = 1,
                PageSize = 100
            };

            var lopBienChes = await _lopBienCheApiClient.GetAllPaging(requestLopBienChe);
            ViewBag.lopBienChes = lopBienChes.Items;

            //Lấy danh sách ctdt trùng với khóa của sinh viên
            var requestCTDT = new ChuongTrinhDaoTaoPagingRequest()
            {
                Keyword = year,
                PageIndex = 1,
                PageSize = 100
            };
            var chuonTrinhDaoTaos = await _chuongTrinhDaoTaoApiClient.GetAllPaging(requestCTDT);
            ViewBag.chuongTrinhDaoTaos = chuonTrinhDaoTaos.Items;


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
                    ID_ChuongTrinhDaoTao = sinhVien.ID_ChuongTrinhDaoTao
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
                    ID_ChuongTrinhDaoTao = sinhVien.ID_ChuongTrinhDaoTao,
                    ChuongTrinhDaoTao = sinhVien.ChuongTrinhDaoTao
                };
                return View(monHocViewModel);
            }
            return RedirectToAction("Error", "Home");
        }
    }
}
