﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLySinhVien.Service.Catalog.LopHocPhans;
using QuanLySinhVien.ViewModel.Catalog.LopHocPhans;

namespace QuanLySinhVien.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LopHocPhansController : ControllerBase
    {
        private readonly ILopHocPhanService _lopHocPhanService;

        public LopHocPhansController(ILopHocPhanService lopHocPhanService)
        {
            _lopHocPhanService = lopHocPhanService;
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] LopHocPhanManagePagingRequest request)
        {
            var lopHocPhan = await _lopHocPhanService.GetAllPaging(request);
            return Ok(lopHocPhan);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var lopHocPhan = await _lopHocPhanService.GetById(id);
            if (lopHocPhan == null)
                return BadRequest("Not found");
            return Ok(lopHocPhan);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LopHocPhanCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ID_LopHocPhan = await _lopHocPhanService.Create(request);
            if (ID_LopHocPhan == null)
                return BadRequest();

            var lopHocPhan = await _lopHocPhanService.GetById(ID_LopHocPhan);

            return CreatedAtAction(nameof(GetById), new { id = ID_LopHocPhan }, lopHocPhan);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] LopHocPhanUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var affectedResult = await _lopHocPhanService.Update(id, request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();

        }

        [HttpGet("getschedule/{hocky}/{namhoc}")]
        public async Task<IActionResult> GetSchedule(int hocky, int namhoc)
        {
            var lopHocPhan = await _lopHocPhanService.GetSchedule(hocky, namhoc);
            return Ok(lopHocPhan);
        }

        [HttpPut("schedule/{hocky}/{namhoc}")]
        public async Task<IActionResult> Schedule(int hocky, int namhoc, [FromBody] ScheduleCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var affectedResult = await _lopHocPhanService.Schedule(hocky, namhoc, request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
    }
}
