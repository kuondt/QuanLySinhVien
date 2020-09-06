using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QuanLySinhVien.AdminApp.Services.ChiTietChuongTrinhDaoTao;
using QuanLySinhVien.AdminApp.Services.ChuongTrinhDaoTao;
using QuanLySinhVien.AdminApp.Services.MonHoc;
using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.ViewModel.Catalog.ChiTietChuongTrinhDaoTaos;
using QuanLySinhVien.ViewModel.Catalog.ChuongTrinhDaoTaos;

namespace QuanLySinhVien.AdminApp.Controllers
{
    public class ChuongTrinhDaoTaoController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IChuongTrinhDaoTaoApiClient _chuongTrinhDaoTao;
        private readonly IChiTietChuongTrinhDaoTaoApiClient _chiTietCTDT;
        private readonly IMonHocApiClient _monHocApiClient;

        public ChuongTrinhDaoTaoController(IConfiguration configuration, IChuongTrinhDaoTaoApiClient chuongTrinhDaoTaoApiClient, IChiTietChuongTrinhDaoTaoApiClient chiTietChuongTrinhDaoTaoApiClient,
            IMonHocApiClient monHocApiClient)
        {
            _configuration = configuration;
            _chuongTrinhDaoTao = chuongTrinhDaoTaoApiClient;
            _chiTietCTDT = chiTietChuongTrinhDaoTaoApiClient;
            _monHocApiClient = monHocApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 3)
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
            var chuongTrinhDaoTao = await _chuongTrinhDaoTao.GetById(id);

            //Lấy danh sách môn học
            var requestChiTietCTDT = new ChiTietChuongTrinhDaoTaoPagingRequest()
            {    
                Keyword = id,
                PageIndex = 1,
                PageSize = 100
            };
            var listChiTietCTDT = await _chiTietCTDT.GetAllPaging(requestChiTietCTDT);

            var lst = listChiTietCTDT.Items.ToList();

            if (chuongTrinhDaoTao != null)
            {
                var monHocViewModel = new ChuongTrinhDaoTaoViewModel()
                {
                    ID = chuongTrinhDaoTao.ID,
                    Id_Khoa = chuongTrinhDaoTao.Id_Khoa,
                    Nam = chuongTrinhDaoTao.Nam,
                    TenChuongTrinh = chuongTrinhDaoTao.TenChuongTrinh,                   
                    ChiTiet_ChuongTrinhDaoTao_MonHocs = chuongTrinhDaoTao.ChiTiet_ChuongTrinhDaoTao_MonHocs                  
                    
                };

                return View(monHocViewModel);
            }
            return RedirectToAction("Error", "Home");
        }
    }
}
