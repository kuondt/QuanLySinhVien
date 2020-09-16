using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QuanLySinhVien.AdminApp.Services.LopHocPhan;

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

        public IActionResult Index()
        {
            return View();
        }
    }
}
