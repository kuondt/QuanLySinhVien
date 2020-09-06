using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QuanLySinhVien.AdminApp.Services.ChiTietChuongTrinhDaoTao;
using QuanLySinhVien.ViewModel.Catalog.ChiTietChuongTrinhDaoTaos;

namespace QuanLySinhVien.AdminApp.Controllers.Components
{
    public class ChiTietChuongTrinhDaoTaoController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IChiTietChuongTrinhDaoTaoApiClient _chiTietCTDT;

        public ChiTietChuongTrinhDaoTaoController(IConfiguration configuration, IChiTietChuongTrinhDaoTaoApiClient chiTietChuongTrinhDaoTaoApiClient)
        {
            _configuration = configuration;
            _chiTietCTDT = chiTietChuongTrinhDaoTaoApiClient;
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
    }
}
