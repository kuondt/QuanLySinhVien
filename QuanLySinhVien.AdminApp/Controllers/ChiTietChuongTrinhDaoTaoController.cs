﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace QuanLySinhVien.AdminApp.Controllers.Components
{
    public class ChiTietChuongTrinhDaoTaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}