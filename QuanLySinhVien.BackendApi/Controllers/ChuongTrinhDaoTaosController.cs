using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLySinhVien.Service.Catalog.ChuongTrinhDaoTaos;
using QuanLySinhVien.ViewModel.Catalog.ChuongTrinhDaoTaos;

namespace QuanLySinhVien.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChuongTrinhDaoTaosController : ControllerBase
    {
        private readonly IChuongTrinhDaoTaoService _chuongTrinhDaoTaoService;

        public ChuongTrinhDaoTaosController(IChuongTrinhDaoTaoService chuongTrinhDaoTaoService)
        {
            _chuongTrinhDaoTaoService = chuongTrinhDaoTaoService;
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] ChuongTrinhDaoTaoPagingRequest request)
        {
            var chuongTrinhDaoTao = await _chuongTrinhDaoTaoService.GetAllPaging(request);
            return Ok(chuongTrinhDaoTao);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var ctdt = await _chuongTrinhDaoTaoService.GetById(id);
            if (ctdt == null)
                return BadRequest("Not found");
            return Ok(ctdt);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ChuongTrinhDaoTaoCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ID_ChuongTrinhDaoTao = await _chuongTrinhDaoTaoService.Create(request);
            if (ID_ChuongTrinhDaoTao == null)
                return BadRequest();

            var chuongTrinhDaoTao = await _chuongTrinhDaoTaoService.GetById(ID_ChuongTrinhDaoTao);

            return CreatedAtAction(nameof(GetById), new { id = ID_ChuongTrinhDaoTao }, chuongTrinhDaoTao);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] ChuongTrinhDaoTaoUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var affectedResult = await _chuongTrinhDaoTaoService.Update(id, request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();

        }
    }
}
