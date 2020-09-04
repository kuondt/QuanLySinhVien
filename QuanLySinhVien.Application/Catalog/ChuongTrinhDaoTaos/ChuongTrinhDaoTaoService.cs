using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien.ViewModel.Catalog.ChuongTrinhDaoTaos;
using System.Linq;
using QuanLySinhVien.Data.EF;
using QuanLySinhVien.Data.Entities;

namespace QuanLySinhVien.Service.Catalog.ChuongTrinhDaoTaos
{
    public class ChuongTrinhDaoTaoService : IChuongTrinhDaoTaoService
    {
        private readonly QLSV_DBContext _context;

        public ChuongTrinhDaoTaoService(QLSV_DBContext context)
        {
            _context = context;
        }

        public async Task<string> Create(ChuongTrinhDaoTaoViewModel request)
        {
            //STT mặc định là 1
            //STT = số thứ tự cuối cùng năm đó + 1
            int soThuTu = 1;
            var sttCuoiCung_CuaNam = _context.ChuongTrinhDaoTaos
                                                .Where(x => x.Nam == request.Nam)
                                                .Select(x => x.SoThuTu)
                                                .ToArray()
                                                .LastOrDefault();
            soThuTu += sttCuoiCung_CuaNam;

            //Lấy năm hiện tại
            string year = request.Nam.ToString();

            //Ghép chuỗi tạo ID
            string Id = year + "CNTT" + soThuTu.ToString().PadLeft(2, '0');

            var chuongTrinhDaoTao = new ChuongTrinhDaoTao()
            {
                ID = Id,
                SoThuTu = soThuTu,               
                Nam = request.Nam,
                Id_Khoa = request.Id_Khoa,
                
            };

            _context.ChuongTrinhDaoTaos.Add(chuongTrinhDaoTao);
            await _context.SaveChangesAsync();

            return chuongTrinhDaoTao.ID;
        }

        public async Task<PagedResult<ChuongTrinhDaoTaoViewModel>> GetAllPaging(ChuongTrinhDaoTaoViewModel request)
        {
            var query = from sv
                        in _context.SinhViens
                        select new { sv };

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.sv.HoTen.Contains(request.Keyword) || x.sv.ID.Contains(request.Keyword));
            }

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new SinhVienViewModel()
                {
                    ID = x.sv.ID,
                    SoThuTu = x.sv.SoThuTu,
                    Ho = x.sv.Ho,
                    Ten = x.sv.Ten,
                    HoTen = x.sv.HoTen,
                    DiaChi = x.sv.DiaChi,
                    Email = x.sv.Email,
                    SoDienThoai = x.sv.SoDienThoai,
                    GioiTinh = x.sv.GioiTinh,
                    NgaySinh = x.sv.NgaySinh,
                    IsActive = x.sv.IsActive,
                    Nam = x.sv.Nam,
                    ID_LopBienChe = x.sv.ID_LopBienChe,

                }).ToListAsync();

            var pagedResult = new PagedResult<ChuongTrinhDaoTaoViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return pagedResult;
        }

        public async Task<ChuongTrinhDaoTaoViewModel> GetById(string id)
        {
            var sinhVien = await _context.SinhViens.FindAsync(id);

            if (sinhVien == null)
            {
                throw new QuanLySinhVien_Exceptions($"Không thể tìm thấy: {id}");
            }

            var lopBienChe = _context.LopBienChes
                                    .Where(x => x.ID.Contains(sinhVien.ID_LopBienChe))
                                    .FirstOrDefault();



            var sinhVienViewModel = new ChuongTrinhDaoTaoViewModel()
            {
                ID = sinhVien.ID,
                SoThuTu = sinhVien.SoThuTu,
                Ho = sinhVien.Ho,
                Ten = sinhVien.Ten,
                HoTen = sinhVien.HoTen,
                DiaChi = sinhVien.DiaChi,
                Email = sinhVien.Email,
                SoDienThoai = sinhVien.SoDienThoai,
                GioiTinh = sinhVien.GioiTinh,
                NgaySinh = sinhVien.NgaySinh,
                IsActive = sinhVien.IsActive,
                ID_LopBienChe = sinhVien.ID_LopBienChe,
                Nam = sinhVien.Nam,
                LopBienChe = lopBienChe
            };
            return sinhVienViewModel;
        }

        public async Task<int> Update(string id, ChuongTrinhDaoTaoViewModel request)
        {
            var sinhVien = await _context.SinhViens.FindAsync(id);

            if (sinhVien == null)
            {
                throw new QuanLySinhVien_Exceptions($"Không thể tìm thấy: {id}");
            }
            sinhVien.Ho = request.Ho;
            sinhVien.Ten = request.Ten;
            sinhVien.HoTen = request.Ho + " " + request.Ten;
            sinhVien.DiaChi = request.DiaChi;
            sinhVien.Email = request.Email;
            sinhVien.SoDienThoai = request.SoDienThoai;
            sinhVien.GioiTinh = request.GioiTinh;
            sinhVien.NgaySinh = request.NgaySinh;
            sinhVien.IsActive = request.IsActive;
            sinhVien.ID_LopBienChe = request.ID_LopBienChe;


            if (request.IsActive == Status.InActive)
            {
                sinhVien.ID_LopBienChe = null;
            }
            return await _context.SaveChangesAsync();
        }
    }
}
