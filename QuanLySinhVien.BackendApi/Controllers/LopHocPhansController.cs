using System;
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]LopHocPhanCreateRequest request)
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
    }
}
