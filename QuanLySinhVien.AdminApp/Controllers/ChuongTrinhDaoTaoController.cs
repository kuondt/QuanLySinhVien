using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QuanLySinhVien.AdminApp.Services.ChiTietChuongTrinhDaoTao;
using QuanLySinhVien.AdminApp.Services.ChuongTrinhDaoTao;
using QuanLySinhVien.AdminApp.Services.HocKyNamHoc;
using QuanLySinhVien.AdminApp.Services.MonHoc;
using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.ViewModel.Catalog.ChiTietChuongTrinhDaoTaos;
using QuanLySinhVien.ViewModel.Catalog.ChuongTrinhDaoTaos;
using QuanLySinhVien.ViewModel.Catalog.HocKyNamHocs;
using QuanLySinhVien.ViewModel.Catalog.MonHocs;

namespace QuanLySinhVien.AdminApp.Controllers
{
    public class ChuongTrinhDaoTaoController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IChuongTrinhDaoTaoApiClient _chuongTrinhDaoTao;
        private readonly IChiTietChuongTrinhDaoTaoApiClient _chiTietCTDT;
        private readonly IMonHocApiClient _monHocApiClient;
        private readonly IHocKyNamHocApiClient _hocKyNamHocApiClient;

        public ChuongTrinhDaoTaoController(IConfiguration configuration, IChuongTrinhDaoTaoApiClient chuongTrinhDaoTaoApiClient, IChiTietChuongTrinhDaoTaoApiClient chiTietChuongTrinhDaoTaoApiClient,
            IMonHocApiClient monHocApiClient, IHocKyNamHocApiClient hocKyNamHocApiClient)
        {
            _configuration = configuration;
            _chuongTrinhDaoTao = chuongTrinhDaoTaoApiClient;
            _chiTietCTDT = chiTietChuongTrinhDaoTaoApiClient;
            _monHocApiClient = monHocApiClient;
            _hocKyNamHocApiClient = hocKyNamHocApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var request = new ChuongTrinhDaoTaoPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _chuongTrinhDaoTao.GetAllPaging(request);

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
            string khoa = "CNTT";
            ViewBag.lopBienChes = khoa;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ChuongTrinhDaoTaoCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _chuongTrinhDaoTao.Create(request);
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
            var chuongTrinhDaoTao = await _chuongTrinhDaoTao.GetById(id);

            var updateRequest = new ChuongTrinhDaoTaoUpdateRequest()
            {
                TenChuongTrinh = chuongTrinhDaoTao.TenChuongTrinh
            };
            return View(updateRequest);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, ChuongTrinhDaoTaoUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _chuongTrinhDaoTao.Update(id, request);
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
            var requestChiTietCTDT = new ChiTietChuongTrinhDaoTaoPagingRequest()
            {
                Keyword = id,
                PageIndex = 1,
                PageSize = 100
            };

            var chiTietCTDT = await _chiTietCTDT.GetAllByIdChuongTrinhDaoTao(requestChiTietCTDT);

            if (chiTietCTDT != null)
            {
                if (TempData["result"] != null)
                {
                    ViewBag.SuccessMessage = TempData["result"];
                }

                ViewBag.ID_CTDT = id;

                return View(chiTietCTDT);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> CreateChiTietCTDT(string id)
        {
            var namApDung = await _chuongTrinhDaoTao.GetById(id);
            var nam = namApDung.Nam;
            ViewBag.Nam = nam;

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

            ViewBag.ID_CTDT = id;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateChiTietCTDT(string id, ChiTietChuongTrinhDaoTaoCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _chiTietCTDT.Create(request);
            if (result)
            {
                TempData["result"] = "Thêm mới thành công";

                return RedirectToAction("Details", new { id = id });
            }

            ModelState.AddModelError("", "Môn học đã tồn tại trong chương trình");
            return View(request);
        }

        [HttpGet("ChuongTrinhDaoTao/{idctdt}/{idmonhoc}")]
        public async Task<IActionResult> DeleteChiTietCTDT(string idctdt, string idmonhoc)
        {
            var chiTietCTDT = await _chiTietCTDT.GetById(idctdt, idmonhoc);

            if (chiTietCTDT != null)
            {
                var updateRequest = new ChiTietChuongTrinhDaoTaoUpdateRequest()
                {
                    ID_MonHoc = chiTietCTDT.ID_MonHoc
                };
                return View(updateRequest);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost("ChuongTrinhDaoTao/{idctdt}/{idmonhoc}")]
        public async Task<IActionResult> DeleteChiTietCTDT(string idctdt, string idmonhoc, ChiTietChuongTrinhDaoTaoUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _chiTietCTDT.Delete(idctdt, idmonhoc);
            if (result)
            {
                TempData["result"] = "Xóa thành công";
                return RedirectToAction("Details", new { id = idctdt });
            }

            ModelState.AddModelError("", "Xóa không thành công");
            return View(request);
        }
    }
}
