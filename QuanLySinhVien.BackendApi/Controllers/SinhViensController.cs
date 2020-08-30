using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLySinhVien.Service.Catalog.SinhViens;
using QuanLySinhVien.ViewModel.Catalog.SinhViens;

namespace QuanLySinhVien.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhViensController : ControllerBase
    {
        private readonly ISinhVienService _sinhVienService;

        public SinhViensController(ISinhVienService sinhVienService)
        {
            _sinhVienService = sinhVienService;
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] SinhVienManagePagingRequest request)
        {
            var sinhVien = await _sinhVienService.GetAllPaging(request);
            return Ok(sinhVien);
        }

    }
}
