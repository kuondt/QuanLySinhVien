using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QuanLySinhVien.AdminApp.Services.LopHocPhan;
using QuanLySinhVien.ViewModel.Catalog.LopHocPhans;

namespace QuanLySinhVien.AdminApp.Controllers
{
    public class LopHocPhanController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly ILopHocPhanApiClient _lopHocPhanApiClient;

        public LopHocPhanController(IConfiguration configuration, ILopHocPhanApiClient lopHocPhanApiClient)
        {
            _configuration = configuration;           
            _lopHocPhanApiClient = lopHocPhanApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 3)
        {
            var request = new LopHocPhanManagePagingRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _lopHocPhanApiClient.GetAllPaging(request);

            ViewBag.Keyword = keyword;

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMessage = TempData["result"];
            }

            return View(data);
        }
    }
}
