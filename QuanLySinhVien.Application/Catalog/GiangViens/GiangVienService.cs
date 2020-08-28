using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.Data.EF;
using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.Data.Enums;
using QuanLySinhVien.ViewModel.Catalog.GiangViens;
using QuanLySinhVien.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Service.Catalog.GiangViens
{
    public class GiangVienService : IGiangVienService
    {
        private readonly QLSV_DBContext _context;
        public GiangVienService(QLSV_DBContext context)
        {
            _context = context;
        }

        public async Task<string> Create(GiangVienCreateRequest request)
        {
            //Chọn STT cuối và cộng thêm 1
            int soThuTu_GiangVien = _context.GiangViens.OrderBy(giangVien => giangVien.ID).ToList().Last().SoThuTu + 1;
            //Ghép chuỗi tạo ID
            string ID_giangVien = "GV" + soThuTu_GiangVien.ToString().PadLeft(3, '0');

            var giangVien = new GiangVien()
            {
                ID = ID_giangVien,
                SoThuTu = soThuTu_GiangVien,
                Ho = request.Ho,
                Ten = request.Ten,
                HoTen = request.Ho + request.Ten,
                ID_Khoa = "KTCN",
                DiaChi = request.DiaChi,
                Email = request.Email,
                SoDienThoai = request.SoDienThoai,
                GioiTinh = request.GioiTinh,
                NgaySinh = request.NgaySinh,
                IsActive = Status.Active,
            };
            _context.GiangViens.Add(giangVien);
            await _context.SaveChangesAsync();
            return giangVien.ID;
        }

        public async Task<PagedResult<GiangVienViewModel>> GetAllPaging(GiangVienManagePagingRequest request)
        {
            var query = from gv
                         in _context.GiangViens
                        select new { gv };

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.gv.HoTen.Contains(request.Keyword) || x.gv.ID.Contains(request.Keyword));
            }

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new GiangVienViewModel()
                {
                    ID = x.gv.ID,
                    SoThuTu = x.gv.SoThuTu,
                    Ho = x.gv.Ho,
                    Ten = x.gv.Ten,
                    HoTen = x.gv.Ho + x.gv.Ten,
                    DiaChi = x.gv.DiaChi,
                    Email = x.gv.Email,
                    SoDienThoai = x.gv.SoDienThoai,
                    GioiTinh = x.gv.GioiTinh,
                    NgaySinh = x.gv.NgaySinh,
                    IsActive = x.gv.IsActive,
                }).ToListAsync();

            var pagedResult = new PagedResult<GiangVienViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return pagedResult;
        }

        public Task<GiangVienViewModel> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(string id, GiangVienUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
