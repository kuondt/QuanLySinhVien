using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLySinhVien.Service.Catalog.Phongs;
using QuanLySinhVien.ViewModel.Catalog.Phongs;

namespace QuanLyPhong.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PhongsController : ControllerBase
    {
        private readonly IPhongService _phongService;

        public PhongsController(IPhongService phongService)
        {
            _phongService = phongService;
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] PhongManagePagingRequest request)
        {
            var phong = await _phongService.GetAllPaging(request);
            return Ok(phong);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var phong = await _phongService.GetById(id);
            if (phong == null)
                return BadRequest("Not found");
            return Ok(phong);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PhongCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ID_phong = await _phongService.Create(request);
            if (ID_phong == null)
                return BadRequest();

            var phong = await _phongService.GetById(ID_phong);

            return CreatedAtAction(nameof(GetById), new { id = ID_phong }, phong);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] PhongUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var affectedResult = await _phongService.Update(id, request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();

        }
    }
}
