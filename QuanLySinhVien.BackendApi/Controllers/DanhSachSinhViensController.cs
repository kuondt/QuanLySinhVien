using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLySinhVien.Service.Catalog.DanhSachSinhViens;
using QuanLySinhVien.ViewModel.Catalog.DanhSachSinhViens;

namespace QuanLySinhVien.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DanhSachSinhViensController : ControllerBase
    {
        private readonly IDanhSachSinhVienService _danhSachSinhVienService;

        public DanhSachSinhViensController(IDanhSachSinhVienService danhSachSinhVienService)
        {
            _danhSachSinhVienService = danhSachSinhVienService;
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllByIdChuongTrinhDaoTao([FromQuery] DanhSachSinhVienPagingRequest request)
        {
            var chuongTrinhDaoTao = await _danhSachSinhVienService.GetAllByIdLopHocPhan(request);
            return Ok(chuongTrinhDaoTao);
        }


    }
}
