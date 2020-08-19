using QuanLySinhVien.Data.EF;
using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.ViewModel.Catalog.MonHocs;
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

        public async Task<string> Create(MonHoc_CreateRequest request)
        {
            var lastID_MonHoc = _context.MonHocs.OrderBy(monHoc => monHoc.ID).ToList().Last().ID + 1;
            string ID_MonHoc = "INT" + lastID_MonHoc.ToString().PadLeft(3,'0');

            var monHoc = new MonHoc()
            {
                ID = ID_MonHoc,
                TenMonHoc = request.TenMonHoc,
                SoTinChi = request.SoTinChi,
                SoTiet = request.SoTiet,
                ID_Khoa = request.ID_Khoa
            };
            _context.MonHocs.Add(monHoc);
            await _context.SaveChangesAsync();
            return monHoc.ID;
        }

        public async Task<MonHoc_ViewModel> GetById(string ID_MonHoc)
        {
            var monHoc = await _context.MonHocs.FindAsync(ID_MonHoc);          

            var monHocViewModel = new MonHoc_ViewModel()
            {
                ID = monHoc.ID,
                TenMonHoc = monHoc.TenMonHoc,
                SoTiet = monHoc.SoTiet,
                SoTinChi = monHoc.SoTinChi,
                ID_Khoa = monHoc.ID_Khoa
            };
            return monHocViewModel;
        }

        public async Task<int> Update(MonHoc_UpdateRequest request)
        {
            var monHoc = await _context.MonHocs.FindAsync(request.ID);

            if (monHoc == null)
            {
                throw new QuanLySinhVien_Exceptions($"Không thể tìm thấy mã: {request.ID}");
            }

            monHoc.TenMonHoc = request.TenMonHoc;
            monHoc.SoTiet = request.SoTiet;
            monHoc.SoTinChi = request.SoTinChi;

            return await _context.SaveChangesAsync();
        }
    }
}
