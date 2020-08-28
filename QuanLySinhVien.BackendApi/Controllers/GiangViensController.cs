using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLySinhVien.Service.Catalog.GiangViens;
using QuanLySinhVien.ViewModel.Catalog.GiangViens;

namespace QuanLySinhVien.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GiangViensController : ControllerBase
    {
        private readonly IGiangVienService _giangVienService;

        public GiangViensController(IGiangVienService giangVienService)
        {
            _giangVienService = giangVienService;
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GiangVienManagePagingRequest request)
        {
            var giangVien = await _giangVienService.GetAllPaging(request);
            return Ok(giangVien);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var giangVien = await _giangVienService.GetById(id);
            if (giangVien == null)
                return BadRequest("Not found");
            return Ok(giangVien);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GiangVienCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ID_giangVien = await _giangVienService.Create(request);
            if (ID_giangVien == null)
                return BadRequest();

            var giangVien = await _giangVienService.GetById(ID_giangVien);

            return CreatedAtAction(nameof(GetById), new { id = ID_giangVien }, giangVien);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] GiangVienUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var affectedResult = await _giangVienService.Update(id, request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();

        }

        //[HttpPut("isactive/{id}")]
        //public async Task<IActionResult> IsActiveUpdate(string id)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var affectedResult = await _giangVienService.IsActiveUpdate(id);
        //    if (affectedResult == 0)
        //        return BadRequest();
        //    return Ok();

        //}
    }
}
