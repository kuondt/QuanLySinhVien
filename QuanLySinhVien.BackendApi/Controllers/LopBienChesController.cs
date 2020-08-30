using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLySinhVien.Service.Catalog.LopBienChes;
using QuanLySinhVien.ViewModel.Catalog.LopBienChes;

namespace QuanLySinhVien.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LopBienChesController : ControllerBase
    {
        private readonly ILopBienCheService _lopBienCheService;

        public LopBienChesController(ILopBienCheService lopBienCheService)
        {
            _lopBienCheService = lopBienCheService;
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] LopBienCheManagePagingRequest request)
        {
            var lopBienChe = await _lopBienCheService.GetAllPaging(request);
            return Ok(lopBienChe);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var lopBienChe = await _lopBienCheService.GetById(id);
            if (lopBienChe == null)
                return BadRequest("Not found");
            return Ok(lopBienChe);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LopBienCheCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ID_lopBienChe = await _lopBienCheService.Create(request);
            if (ID_lopBienChe == null)
                return BadRequest();

            var lopBienChe = await _lopBienCheService.GetById(ID_lopBienChe);

            return CreatedAtAction(nameof(GetById), new { id = ID_lopBienChe }, lopBienChe);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] LopBienCheUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var affectedResult = await _lopBienCheService.Update(id, request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var affectedResult = await _lopBienCheService.Delete(id);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();

        }
    }
}
