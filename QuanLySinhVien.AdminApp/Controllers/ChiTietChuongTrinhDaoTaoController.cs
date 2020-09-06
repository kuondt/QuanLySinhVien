using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QuanLySinhVien.AdminApp.Services.ChiTietChuongTrinhDaoTao;
using QuanLySinhVien.AdminApp.Services.HocKyNamHoc;
using QuanLySinhVien.AdminApp.Services.MonHoc;
using QuanLySinhVien.ViewModel.Catalog.ChiTietChuongTrinhDaoTaos;
using QuanLySinhVien.ViewModel.Catalog.HocKyNamHocs;
using QuanLySinhVien.ViewModel.Catalog.MonHocs;

namespace QuanLySinhVien.AdminApp.Controllers.Components
{
    public class ChiTietChuongTrinhDaoTaoController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IChiTietChuongTrinhDaoTaoApiClient _chiTietCTDT;
        private readonly IMonHocApiClient _monHocApiClient;
        private readonly IHocKyNamHocApiClient _hocKyNamHocApiClient;

        public ChiTietChuongTrinhDaoTaoController(IConfiguration configuration, IChiTietChuongTrinhDaoTaoApiClient chiTietChuongTrinhDaoTaoApiClient, IMonHocApiClient monHocApiClient, IHocKyNamHocApiClient hocKyNamHocApiClient)
        {
            _configuration = configuration;
            _chiTietCTDT = chiTietChuongTrinhDaoTaoApiClient;
            _monHocApiClient = monHocApiClient;
            _hocKyNamHocApiClient = hocKyNamHocApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 3)
        {
            var request = new ChiTietChuongTrinhDaoTaoPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _chiTietCTDT.GetAllByIdChuongTrinhDaoTao(request);

            ViewBag.Keyword = keyword;

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMessage = TempData["result"];
            }

            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Create(string id_CTDT)
        {
            //Lấy danh sách môn học để show thành list
            var requestMonHoc = new MonHocManagePagingRequest()
            {
                PageIndex = 1,
                PageSize = 1000
            };
            var monHocs = await _monHocApiClient.GetAllPaging(requestMonHoc);
            ViewBag.monHocs = monHocs.Items;

            //Lấy danh sách học kỳ để show thành list
            var requestHocKy = new HocKyNamHocManagePagingRequest()
            {
                PageIndex = 1,
                PageSize = 1000
            };

            var hocKys = await _hocKyNamHocApiClient.GetAllPaging(requestHocKy);
            ViewBag.hocKys = hocKys.Items;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ChiTietChuongTrinhDaoTaoCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _chiTietCTDT.Create(request);
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
