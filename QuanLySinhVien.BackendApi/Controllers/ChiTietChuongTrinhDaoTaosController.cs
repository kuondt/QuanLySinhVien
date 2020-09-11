using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLySinhVien.Service.Catalog.ChiTietChuongTrinhDaoTaos;
using QuanLySinhVien.ViewModel.Catalog.ChiTietChuongTrinhDaoTaos;

namespace QuanLySinhVien.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChiTietChuongTrinhDaoTaosController : ControllerBase
    {
        private readonly IChiTietChuongTrinhDaoTaoService _chiTietChuongTrinhDaoTaoService;

        public ChiTietChuongTrinhDaoTaosController(IChiTietChuongTrinhDaoTaoService chiTietChuongTrinhDaoTaoService)
        {
            _chiTietChuongTrinhDaoTaoService = chiTietChuongTrinhDaoTaoService;
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllByIdChuongTrinhDaoTao([FromQuery] ChiTietChuongTrinhDaoTaoPagingRequest request)
        {
            var chuongTrinhDaoTao = await _chiTietChuongTrinhDaoTaoService.GetAllByIdChuongTrinhDaoTao(request);
            return Ok(chuongTrinhDaoTao);
        }

        [HttpGet("{id_CTDT}/{id_MonHoc}")]
        public async Task<IActionResult> GetById(string id_CTDT, string id_MonHoc)
        {
            var ctdt = await _chiTietChuongTrinhDaoTaoService.GetById(id_CTDT, id_MonHoc);
            if (ctdt == null)
                return BadRequest("Not found");
            return Ok(ctdt);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ChiTietChuongTrinhDaoTaoCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ID_ChuongTrinhDaoTao = await _chiTietChuongTrinhDaoTaoService.Create(request);
            if (ID_ChuongTrinhDaoTao == null)
                return BadRequest();

            var chuongTrinhDaoTao = await _chiTietChuongTrinhDaoTaoService.GetById(ID_ChuongTrinhDaoTao.Item1, ID_ChuongTrinhDaoTao.Item2);

            return CreatedAtAction(nameof(GetById), new { id_CTDT = ID_ChuongTrinhDaoTao.Item1, id_MonHoc = ID_ChuongTrinhDaoTao.Item2}, chuongTrinhDaoTao);
        }

        //[HttpPut("{id_CTDT}/{id_MonHoc}/{hocKy}/{namHoc}")]
        //public async Task<IActionResult> Update(string id_CTDT, string id_MonHoc, int hocKy, int namHoc, [FromBody] ChiTietChuongTrinhDaoTaoUpdateRequest request)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var affectedResult = await _chiTietChuongTrinhDaoTaoService.Update(id_CTDT, id_MonHoc, hocKy, namHoc, request);
        //    if (affectedResult == 0)
        //        return BadRequest();
        //    return Ok();

        //}

        [HttpDelete("{id_CTDT}/{id_MonHoc}")]
        public async Task<IActionResult> Delete(string id_CTDT, string id_MonHoc)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var affectedResult = await _chiTietChuongTrinhDaoTaoService.Delete(id_CTDT, id_MonHoc);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();

        }
    }
}
