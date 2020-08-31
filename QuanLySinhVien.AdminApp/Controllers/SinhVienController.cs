using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QuanLySinhVien.AdminApp.Services.SinhVien;

namespace QuanLySinhVien.AdminApp.Controllers
{
    public class SinhVienController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly ISinhVienApiClient _sinhVienApiClient;

        public SinhVienController(IConfiguration configuration, ISinhVienApiClient sinhVienApiClient)
        {
            _sinhVienApiClient = sinhVienApiClient;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
