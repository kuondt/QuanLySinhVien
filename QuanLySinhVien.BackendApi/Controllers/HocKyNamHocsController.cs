using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLySinhVien.Service.Catalog.HocKyNamHocs;
using QuanLySinhVien.ViewModel.Catalog.HocKyNamHocs;

namespace QuanLySinhVien.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HocKyNamHocsController : ControllerBase
    {
        private readonly IHocKyNamHocService _hocKyNamHocService;
        public HocKyNamHocsController(IHocKyNamHocService hocKyNamHocService)
        {
            _hocKyNamHocService = hocKyNamHocService;
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] HocKyNamHocManagePagingRequest request)
        {
            var hocKyNamHoc = await _hocKyNamHocService.GetAllPaging(request);
            return Ok(hocKyNamHoc);
        }

        [HttpGet("{hocky}/{namhoc}")]
        public async Task<IActionResult> GetById(int hocky, int namhoc)
        {
            var hocKyNamHoc = await _hocKyNamHocService.GetById(hocky, namhoc);
            if (hocKyNamHoc == null)
                return BadRequest("Not found");
            return Ok(hocKyNamHoc);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] HocKyNamHocCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ID_hocKyNamHoc = await _hocKyNamHocService.Create(request);
            if (ID_hocKyNamHoc == null)
                return BadRequest();

            var hocKyNamHoc = await _hocKyNamHocService.GetById(ID_hocKyNamHoc.Item1, ID_hocKyNamHoc.Item2);

            return CreatedAtAction(nameof(GetById), new { hocky = ID_hocKyNamHoc.Item1 , namhoc = ID_hocKyNamHoc.Item2}, hocKyNamHoc);
        }

        [HttpPut("{hocky}/{namhoc}")]
        public async Task<IActionResult> Update(int hocky, int namhoc, [FromBody] HocKyNamHocUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var affectedResult = await _hocKyNamHocService.Update(hocky, namhoc, request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();

        }
    }
}
