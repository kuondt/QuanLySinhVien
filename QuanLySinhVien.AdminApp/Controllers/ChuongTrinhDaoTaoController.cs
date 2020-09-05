using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QuanLySinhVien.AdminApp.Services.ChuongTrinhDaoTao;
using QuanLySinhVien.ViewModel.Catalog.ChuongTrinhDaoTaos;

namespace QuanLySinhVien.AdminApp.Controllers
{
    public class ChuongTrinhDaoTaoController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IChuongTrinhDaoTaoApiClient _chuongTrinhDaoTaoApiClient;

        public ChuongTrinhDaoTaoController(IConfiguration configuration, IChuongTrinhDaoTaoApiClient chuongTrinhDaoTaoApiClient)
        {
            _configuration = configuration;
            _chuongTrinhDaoTaoApiClient = chuongTrinhDaoTaoApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 3)
        {
            var request = new ChuongTrinhDaoTaoPagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _chuongTrinhDaoTaoApiClient.GetAllPaging(request);

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

            var result = await _chuongTrinhDaoTaoApiClient.Create(request);
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
