using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLySinhVien.Service.Catalog.SinhViens;
using QuanLySinhVien.ViewModel.Catalog.SinhViens;

namespace QuanLySinhVien.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var sinhVien = await _sinhVienService.GetById(id);
            if (sinhVien == null)
                return BadRequest("Not found");
            return Ok(sinhVien);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SinhVienCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ID_sinhVien = await _sinhVienService.Create(request);
            if (ID_sinhVien == null)
                return BadRequest();

            var sinhVien = await _sinhVienService.GetById(ID_sinhVien);

            return CreatedAtAction(nameof(GetById), new { id = ID_sinhVien }, sinhVien);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] SinhVienUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var affectedResult = await _sinhVienService.Update(id, request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();

        }
    }
}
