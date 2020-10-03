using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using QuanLySinhVien.AdminApp.Services.DanhSachSinhVien;
using QuanLySinhVien.AdminApp.Services.GiangVien;
using QuanLySinhVien.AdminApp.Services.LopHocPhan;
using QuanLySinhVien.AdminApp.Services.MonHoc;
using QuanLySinhVien.AdminApp.Services.Phong;
using QuanLySinhVien.AdminApp.Services.SinhVien;
using QuanLySinhVien.ViewModel.Catalog.DanhSachSinhViens;
using QuanLySinhVien.ViewModel.Catalog.GiangViens;
using QuanLySinhVien.ViewModel.Catalog.LopHocPhans;
using QuanLySinhVien.ViewModel.Catalog.MonHocs;
using QuanLySinhVien.ViewModel.Catalog.Phongs;
using QuanLySinhVien.ViewModel.Catalog.SinhViens;

namespace QuanLySinhVien.AdminApp.Controllers
{
    public class LopHocPhanController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly ILopHocPhanApiClient _lopHocPhanApiClient;
        private readonly IPhongApiClient _phongApiClient;
        private readonly IMonHocApiClient _monHocApiClient;
        private readonly IGiangVienApiClient _giangVienApiClient;
        private readonly IDanhSachSinhVienApiClient _danhSachSinhVienApiClient;
        private readonly ISinhVienApiClient _sinhVienApiClient;

        public LopHocPhanController(IConfiguration configuration, ILopHocPhanApiClient lopHocPhanApiClient, IPhongApiClient phongApiClient, IMonHocApiClient monHocApiClient, IGiangVienApiClient giangVienApiClient, IDanhSachSinhVienApiClient danhSachSinhVienApiClient, ISinhVienApiClient sinhVienApiClient)
        {
            _configuration = configuration;
            _lopHocPhanApiClient = lopHocPhanApiClient;
            _phongApiClient = phongApiClient;
            _monHocApiClient = monHocApiClient;
            _giangVienApiClient = giangVienApiClient;
            _danhSachSinhVienApiClient = danhSachSinhVienApiClient;
            _sinhVienApiClient = sinhVienApiClient;
        }

        public async Task<IActionResult> Index(int hocKy, int namHoc, int pageIndex = 1, int pageSize = 1000)
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMessage = TempData["result"];
            }

            var request = new LopHocPhanManagePagingRequest()
            {
                HocKy = hocKy,
                NamHoc = namHoc,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _lopHocPhanApiClient.GetSchedule(request);

            ViewBag.HocKy = hocKy;
            ViewBag.NamHoc = namHoc;

            var requestRoom = new PhongManagePagingRequest()
            {
                PageIndex = 1,
                PageSize = 1000
            };
            var rooms = await _phongApiClient.GetAllPaging(requestRoom);
            int RoomCount = rooms.Items.Count();
            ViewBag.Rooms = rooms.Items;
            ViewBag.RoomCount = RoomCount;

            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int hocky, int namhoc)
        {
            //Lấy danh sách môn học để show thành list
            var requestMonHoc = new MonHocManagePagingRequest()
            {
                PageIndex = 1,
                PageSize = 1000
            };
            var monHocs = await _monHocApiClient.GetAllPaging(requestMonHoc);
            ViewBag.monHocs = monHocs.Items;

            //Lấy danh sách giảng viên để show thành list
            var requestGiangVien = new GiangVienManagePagingRequest()
            {
                PageIndex = 1,
                PageSize = 1000
            };
            var giangViens = await _giangVienApiClient.GetAllPaging(requestGiangVien);
            ViewBag.GiangViens = giangViens.Items;

            // Lấy danh sách giảng viên để show thành list
            var requestPhong = new PhongManagePagingRequest()
            {
                PageIndex = 1,
                PageSize = 1000
            };
            var phongs = await _phongApiClient.GetAllPaging(requestPhong);
            ViewBag.Phongs = phongs.Items;

            //Lấy hk nam học
            var lopHocPhanCreateRequest = new LopHocPhanCreateRequest()
            {
                HK_HocKy = hocky,
                HK_NamHoc = namhoc
            };
            return View(lopHocPhanCreateRequest);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] LopHocPhanCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _lopHocPhanApiClient.Create(request);
            if (result)
            {
                TempData["result"] = "Thêm mới thành công";
                return RedirectToAction("Index", new { HocKy = request.HK_HocKy, NamHoc = request.HK_NamHoc });
            }

            ModelState.AddModelError("", "Thêm mới thất bại");
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Schedule(ScheduleRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _lopHocPhanApiClient.Schedule(request);
            if (result)
            {
                TempData["result"] = "Cập nhật thành công";
                return RedirectToAction("Index", new { HocKy = request.HocKy, NamHoc = request.NamHoc });
            }

            ModelState.AddModelError("", "Cập nhật không thành công");

            return RedirectToAction("Index", new { HocKy = request.HocKy, NamHoc = request.NamHoc });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            //Lấy danh sách môn học để show thành list
            var requestMonHoc = new MonHocManagePagingRequest()
            {
                PageIndex = 1,
                PageSize = 1000
            };
            var monHocs = await _monHocApiClient.GetAllPaging(requestMonHoc);
            ViewBag.monHocs = monHocs.Items;

            //Lấy danh sách giảng viên để show thành list
            var requestGiangVien = new GiangVienManagePagingRequest()
            {
                PageIndex = 1,
                PageSize = 1000
            };
            var giangViens = await _giangVienApiClient.GetAllPaging(requestGiangVien);
            ViewBag.GiangViens = giangViens.Items;

            // Lấy danh sách giảng viên để show thành list
            var requestPhong = new PhongManagePagingRequest()
            {
                PageIndex = 1,
                PageSize = 1000
            };
            var phongs = await _phongApiClient.GetAllPaging(requestPhong);
            ViewBag.Phongs = phongs.Items;

            //Lấy thông tin lớp học phần cần cập nhật
            var lopHocPhan = await _lopHocPhanApiClient.GetById(id);
            var updateRequest = new LopHocPhanUpdateRequest()
            {
                HK_HocKy = lopHocPhan.HK_HocKy,
                HK_NamHoc = lopHocPhan.HK_NamHoc,
                ID_GiangVien = lopHocPhan.ID_GiangVien,
                ID_MonHoc = lopHocPhan.ID_MonHoc,
                ID_Phong = lopHocPhan.ID_Phong,
                BuoiHoc = lopHocPhan.BuoiHoc,
                NgayHoc = lopHocPhan.NgayHoc              
            };

            return View(updateRequest);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, LopHocPhanUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _lopHocPhanApiClient.Update(id, request);
            if (result)
            {
                TempData["result"] = "Cập nhật thành công";
                return RedirectToAction("Index", new { HocKy = request.HK_HocKy, NamHoc = request.HK_NamHoc });
            }

            ModelState.AddModelError("", "Cập nhật không thành công");
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id, LopHocPhanDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _lopHocPhanApiClient.Delete(id);
            if (result)
            {
                TempData["result"] = $"Xóa thành công lớp {id}";
                return RedirectToAction("Index", new { HocKy = request.HocKy, NamHoc = request.NamHoc });
            }

            ModelState.AddModelError("", $"Xóa không thành công lớp {id}");
            return RedirectToAction("Index", new { HocKy = request.HocKy, NamHoc = request.NamHoc });
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var requestDanhSachSinhVien = new DanhSachSinhVienPagingRequest()
            {
                Keyword = id,
                PageIndex = 1,
                PageSize = 1000
            };

            var infoLopHocPhan = await _lopHocPhanApiClient.GetById(id);

            var danhSachSinhVien = await _danhSachSinhVienApiClient.GetAllByIdLopHocPhan(requestDanhSachSinhVien);

            if (danhSachSinhVien != null)
            {
                if (TempData["result"] != null)
                {
                    ViewBag.SuccessMessage = TempData["result"];
                }
                ViewBag.infoLopHocPhan = infoLopHocPhan;
                ViewBag.ID_LopHocPhan = id;

                return View(danhSachSinhVien);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> AddStudentToClass(string id)
        {

            //Lấy danh sách sinh viên để show thành list
            var requestSinhVien = new SinhVienManagePagingRequest()
            {
                PageIndex = 1,
                PageSize = 1000
            };
            var sinhViens = await _sinhVienApiClient.GetAllPaging(requestSinhVien);
            ViewBag.sinhViens = sinhViens.Items;


            ViewBag.ID_LopHocPhan = id;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStudentToClass(string id, DanhSachSinhVienCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _danhSachSinhVienApiClient.Create(request);
            if (result)
            {
                TempData["result"] = "Thêm mới thành công";
                return RedirectToAction("Details", new { id = id });
            }

            ModelState.AddModelError("", "Sinh viên đã tồn tại trong lớp học phần");
            ViewBag.ID_LopHocPhan = id;
            return View(request);
        }

        [HttpGet("LopHocPhan/Delete/{lophocphan}/{sinhvien}")]
        public async Task<IActionResult> DeleteStudent(string lophocphan, string sinhvien)
        {
            var sinhVien = await _danhSachSinhVienApiClient.GetById(lophocphan, sinhvien);
            var lopHocPhan = await _lopHocPhanApiClient.GetById(lophocphan);

            if (sinhVien != null)
            {
                var updateRequest = new DanhSachSinhVienUpdateRequest()
                {
                    ID_SinhVien = sinhVien.ID_SinhVien
                };
                ViewBag.LopHocPhan = lopHocPhan;
                return View(updateRequest);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost("LopHocPhan/Delete/{lophocphan}/{sinhvien}")]
        public async Task<IActionResult> DeleteStudent(string lophocphan, string sinhvien, DanhSachSinhVienUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _danhSachSinhVienApiClient.Delete(lophocphan, sinhvien);
            if (result)
            {
                TempData["result"] = "Xóa thành công";
                return RedirectToAction("Details", new { id = lophocphan });
            }

            ModelState.AddModelError("", "Xóa không thành công");
            return View(request);
        }
    }
}
