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
            var results = await _danhSachSinhVienService.GetAllByIdLopHocPhan(request);
            return Ok(results);
        }

        [HttpGet("{id_LopHocPhan}/{id_SinhVien}")]
        public async Task<IActionResult> GetById(string id_LopHocPhan, string id_SinhVien)
        {
            var result = await _danhSachSinhVienService.GetById(id_LopHocPhan, id_SinhVien);
            if (result == null)
                return BadRequest("Not found");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DanhSachSinhVienCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var SV_LHP = await _danhSachSinhVienService.Create(request);
            if (SV_LHP == null)
                return BadRequest();

            var chuongTrinhDaoTao = await _danhSachSinhVienService.GetById(SV_LHP.Item1, SV_LHP.Item2);

            return CreatedAtAction(nameof(GetById), new { id_CTDT = SV_LHP.Item1, id_MonHoc = SV_LHP.Item2 }, chuongTrinhDaoTao);
        }

        [HttpPut("{id_LopHocPhan}/{id_SinhVien}")]
        public async Task<IActionResult> Update(string id_LopHocPhan, string id_SinhVien, [FromBody] DanhSachSinhVienUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var affectedResult = await _danhSachSinhVienService.Update(id_LopHocPhan, id_SinhVien, request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{id_LopHocPhan}/{id_SinhVien}")]
        public async Task<IActionResult> Delete(string id_LopHocPhan, string id_SinhVien)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var affectedResult = await _danhSachSinhVienService.Delete(id_LopHocPhan, id_SinhVien);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
    }
}
