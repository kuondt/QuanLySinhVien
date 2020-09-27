using QuanLySinhVien.Data.EF;
using QuanLySinhVien.ViewModel.Catalog.SinhViens;
using QuanLySinhVien.ViewModel.Common;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.Data.Enums;
using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.ViewModel.Exceptions;

namespace QuanLySinhVien.Service.Catalog.SinhViens
{
    public class SinhVienService : ISinhVienService
    {
        private readonly QLSV_DBContext _context;
        public SinhVienService(QLSV_DBContext context)
        {
            _context = context;
        }

        public async Task<string> Create(SinhVienCreateRequest request)
        {
            //STT sinh viên mặc định là 1
            //STT sinh viên = số thứ tự cuối cùng sinh viên năm đó + 1
            int soThuTu_SinhVien = 1;
            var sttCuoiCung_SinhVien_CuaNam = _context.SinhViens
                                                .Where(x => x.Nam == request.Nam)
                                                .Select(x => x.SoThuTu)
                                                .ToArray()
                                                .LastOrDefault();
            soThuTu_SinhVien += sttCuoiCung_SinhVien_CuaNam;

            //Lấy năm hiện tại
            string year = request.Nam.ToString();
            //Lấy 2 số cuối của năm
            string lastTwoDigitsOfYear = year.Substring(year.Length - 2); ;

            //Ghép chuỗi tạo ID
            string ID_SinhVien = lastTwoDigitsOfYear + "1A01" + soThuTu_SinhVien.ToString().PadLeft(4, '0');

            var sinhVien = new SinhVien()
            {
                ID = ID_SinhVien,
                SoThuTu = soThuTu_SinhVien,
                Ho = request.Ho,
                Ten = request.Ten,
                HoTen = request.Ho + " " + request.Ten,
                ID_LopBienChe = request.ID_LopBienChe,
                DiaChi = request.DiaChi,
                Email = request.Email,
                SoDienThoai = request.SoDienThoai,
                GioiTinh = request.GioiTinh,
                NgaySinh = request.NgaySinh,
                IsActive = Status.Active,
                Nam = request.Nam,
                ID_ChuongTrinhDaoTao = request.ID_ChuongTrinhDaoTao
            };

            _context.SinhViens.Add(sinhVien);
            await _context.SaveChangesAsync();

            return sinhVien.ID;
        }

        public async Task<PagedResult<SinhVienViewModel>> GetAllPaging(SinhVienManagePagingRequest request)
        {
            var query = from sv
                        in _context.SinhViens
                        select new { sv };

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.sv.HoTen.Contains(request.Keyword) || x.sv.ID.Contains(request.Keyword) || x.sv.ID_LopBienChe.Contains(request.Keyword));
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

            var pagedResult = new PagedResult<SinhVienViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return pagedResult;
        }

        public async Task<SinhVienViewModel> GetById(string id)
        {
            var sinhVien = await _context.SinhViens.FindAsync(id);

            if (sinhVien == null)
            {
                throw new QuanLySinhVien_Exceptions($"Không thể tìm thấy: {id}");
            }

            var lopBienChe = _context.LopBienChes
                                    .Where(x => x.ID.Contains(sinhVien.ID_LopBienChe))
                                    .FirstOrDefault();

            var chuonTrinhDaoTao = _context.ChuongTrinhDaoTaos
                                    .Where(x => x.ID.Contains(sinhVien.ID_ChuongTrinhDaoTao))
                                    .FirstOrDefault();

            var sinhVienViewModel = new SinhVienViewModel()
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
                LopBienChe = lopBienChe,
                Nam = sinhVien.Nam,
                ID_ChuongTrinhDaoTao = sinhVien.ID_ChuongTrinhDaoTao,
                ChuongTrinhDaoTao = chuonTrinhDaoTao
            };
            return sinhVienViewModel;
        }

        public async Task<int> Update(string id, SinhVienUpdateRequest request)
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
            sinhVien.ID_ChuongTrinhDaoTao = request.ID_ChuongTrinhDaoTao;


            if (request.IsActive == Status.InActive)
            {
                sinhVien.ID_LopBienChe = null;
            }
            return await _context.SaveChangesAsync();
        }
    }
}
