using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLySinhVien.Service.Catalog.MonHocs;
using QuanLySinhVien.ViewModel.Catalog.MonHocs;
using QuanLySinhVien.ViewModel.Common;

namespace QuanLySinhVien.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonHocController : ControllerBase
    {
        private readonly IMonHoc_Service _monHoc_Service;

        public MonHocController(IMonHoc_Service monHoc_Service)
        {
            _monHoc_Service = monHoc_Service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPaging([FromQuery] MonHoc_ManagePagingRequest request)
        {
            var monHoc = await _monHoc_Service.GetAllPaging(request);
            return Ok(monHoc);
        }
    }
}
