using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien.ViewModel.Catalog.ChuongTrinhDaoTaos;
using System.Linq;
using QuanLySinhVien.Data.EF;
using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.ViewModel.Common;
using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.ViewModel.Exceptions;

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

        public async Task<PagedResult<ChuongTrinhDaoTaoViewModel>> GetAllPaging(ChuongTrinhDaoTaoPagingRequest request)
        {
            var query = from ctdt
                        in _context.ChuongTrinhDaoTaos
                        select new { ctdt };

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.ctdt.ID.Contains(request.Keyword) || x.ctdt.TenChuongTrinh.Contains(request.Keyword));
            }

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ChuongTrinhDaoTaoViewModel()
                {
                    ID = x.ctdt.ID,
                    SoThuTu = x.ctdt.SoThuTu,                
                    Nam = x.ctdt.Nam,
                    TenChuongTrinh = x.ctdt.TenChuongTrinh

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
