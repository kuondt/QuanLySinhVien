using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.Data.EF;
using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.ViewModel.Catalog.MonHocs;
using QuanLySinhVien.ViewModel.Common;
using QuanLySinhVien.ViewModel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Service.Catalog.MonHocs
{
    public class MonHoc_Service : IMonHoc_Service
    {
        private readonly QLSV_DBContext _context;
        public MonHoc_Service(QLSV_DBContext context)
        {
            _context = context;
        }

        public async Task<string> Create(MonHocCreateRequest request)
        {
            //Chọn STT cuối và cộng thêm 1
            int soThuTu_MonHoc = _context.MonHocs.OrderBy(monHoc => monHoc.ID).ToList().Last().SoThuTu + 1;
            //Ghép chuỗi tạo ID Môn học
            string ID_MonHoc = "INT" + soThuTu_MonHoc.ToString().PadLeft(3,'0');

            var monHoc = new MonHoc()
            {
                ID = ID_MonHoc,
                SoThuTu = soThuTu_MonHoc,
                TenMonHoc = request.TenMonHoc,
                SoTinChi = request.SoTinChi,
                SoTiet = request.SoTinChi * 15, //2 tín chỉ = 30 tiết
                ID_Khoa = request.ID_Khoa ?? "CNTT"
            };
            _context.MonHocs.Add(monHoc);
            await _context.SaveChangesAsync();
            return monHoc.ID;
        }


        public async Task<MonHocViewModel> GetById(string ID_MonHoc)
        {
            var monHoc = await _context.MonHocs.FindAsync(ID_MonHoc);          

            var monHocViewModel = new MonHocViewModel()
            {
                ID = monHoc.ID,
                TenMonHoc = monHoc.TenMonHoc,
                SoTiet = monHoc.SoTiet,
                SoTinChi = monHoc.SoTinChi,
                ID_Khoa = monHoc.ID_Khoa
            };
            return monHocViewModel;
        }

        public async Task<int> Update(string id, MonHocUpdateRequest request)
        {
            var monHoc = await _context.MonHocs.FindAsync(request.ID);

            if (monHoc == null)
            {
                throw new QuanLySinhVien_Exceptions($"Không thể tìm thấy: {request.ID}");
            }

            monHoc.TenMonHoc = request.TenMonHoc;
            monHoc.SoTinChi = request.SoTinChi;
            monHoc.SoTiet = request.SoTinChi * 15;

            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<MonHocViewModel>> GetAllPaging(MonHocManagePagingRequest request)
        {
            var query = from mh 
                        in _context.MonHocs                     
                        select new { mh };

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.mh.TenMonHoc.Contains(request.Keyword));
            }

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new MonHocViewModel()
                {
                    ID = x.mh.ID,
                    SoThuTu = x.mh.SoThuTu,
                    TenMonHoc = x.mh.TenMonHoc,
                    SoTiet = x.mh.SoTiet,
                    SoTinChi = x.mh.SoTinChi,
                    ID_Khoa = x.mh.ID_Khoa
                }).ToListAsync();

            var pagedResult = new PagedResult<MonHocViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return pagedResult;
        }
    }
}
