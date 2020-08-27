using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLySinhVien.Service.Catalog.MonHocs;
using QuanLySinhVien.ViewModel.Catalog.MonHocs;
using QuanLySinhVien.ViewModel.Common;

namespace QuanLySinhVien.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MonHocsController : ControllerBase
    {
        private readonly IMonHoc_Service _monHoc_Service;

        public MonHocsController(IMonHoc_Service monHoc_Service)
        {
            _monHoc_Service = monHoc_Service;
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] MonHoc_ManagePagingRequest request)
        {
            var monHoc = await _monHoc_Service.GetAllPaging(request);
            return Ok(monHoc);
        }

        [HttpGet("{ID_MonHoc}")]
        public async Task<IActionResult> GetById(string ID_MonHoc)
        {
            var monHoc = await _monHoc_Service.GetById(ID_MonHoc);
            if (monHoc == null)
                return BadRequest("Can not find");
            return Ok(monHoc);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]MonHoc_CreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ID_MonHoc = await _monHoc_Service.Create(request);
            if (ID_MonHoc == null)
                return BadRequest();

            var product = await _monHoc_Service.GetById(ID_MonHoc);

            return CreatedAtAction(nameof(GetById), new { id = ID_MonHoc }, product);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] MonHoc_UpdateRequest request)
        {
            var affectedResult = await _monHoc_Service.Update(request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
    }
}
