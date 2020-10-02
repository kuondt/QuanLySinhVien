using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien.Data.EF;
using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.ViewModel.Catalog.DanhSachSinhViens;
using System.Linq;
using QuanLySinhVien.ViewModel.Common;
using QuanLySinhVien.ViewModel.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace QuanLySinhVien.Service.Catalog.DanhSachSinhViens
{
    public class DanhSachSinhVienService : IDanhSachSinhVienService
    {
        private readonly QLSV_DBContext _context;

        public DanhSachSinhVienService(QLSV_DBContext context)
        {
            _context = context;
        }

        public async Task<Tuple<string, string>> Create(DanhSachSinhVienCreateRequest request)
        {
            var record = new DanhSach_SinhVien_LopHocPhan()
            {
                ID_LopHocPhan = request.ID_LopHocPhan,
                ID_SinhVien = request.ID_SinhVien,             
            };

            _context.DanhSach_SinhVien_LopHocPhans.Add(record);
            await _context.SaveChangesAsync();

            return Tuple.Create(record.ID_LopHocPhan, record.ID_SinhVien);
        }

        public async Task<int> Delete(string id_LopHocPhan, string id_SinhVien)
        {
            var record = await _context.DanhSach_SinhVien_LopHocPhans.FindAsync(id_LopHocPhan, id_SinhVien);


            if (record == null)
            {
                throw new QuanLySinhVien_Exceptions($"Không thể tìm thấy");
            }

            _context.DanhSach_SinhVien_LopHocPhans.Remove(record);
            return await _context.SaveChangesAsync();

        }

        public async Task<PagedResult<DanhSachSinhVienViewModel>> GetAllByIdLopHocPhan (DanhSachSinhVienPagingRequest request)
        {
            var query = from dssv in _context.DanhSach_SinhVien_LopHocPhans
                        join sv in _context.SinhViens on dssv.ID_SinhVien equals sv.ID
                        select new { dssv, sv };

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.dssv.ID_LopHocPhan.Contains(request.Keyword));
            }

            int totalRow = await query.CountAsync();

            var lopHocPhan = await _context.LopHocPhans.FindAsync(request.Keyword);

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new DanhSachSinhVienViewModel()
                {
                    ID_LopHocPhan = x.dssv.ID_LopHocPhan,
                    ID_SinhVien = x.dssv.ID_SinhVien,
                    LopHocPhan = lopHocPhan,
                    SinhVien = x.sv,
                    Diem = x.dssv.Diem,
                    LanThi = x.dssv.LanThi
                }).ToListAsync();

            var pagedResult = new PagedResult<DanhSachSinhVienViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return pagedResult;
        }

        public async Task<DanhSachSinhVienViewModel> GetById(string id_LopHocPhan, string id_SinhVien)
        {
            var danhSachSV = await _context.DanhSach_SinhVien_LopHocPhans.FindAsync(id_LopHocPhan, id_SinhVien);

            var sinhVien = await _context.SinhViens.FindAsync(id_SinhVien);

            var lopHocPhan = await _context.LopHocPhans.FindAsync(id_LopHocPhan);

            if (danhSachSV == null)
            {
                throw new QuanLySinhVien_Exceptions($"Không thể tìm thấy");
            }

            var hocKyNamHocViewModel = new DanhSachSinhVienViewModel()
            {
                ID_LopHocPhan = danhSachSV.ID_LopHocPhan,
                ID_SinhVien = danhSachSV.ID_SinhVien,
                SinhVien = sinhVien,
                LopHocPhan = lopHocPhan,
                Diem = danhSachSV.Diem,
                LanThi = danhSachSV.LanThi
            };
            return hocKyNamHocViewModel;
        }

        public async Task<int> Update(string id_LopHocPhan, string id_SinhVien, DanhSachSinhVienUpdateRequest request)
        {
            var record = await _context.DanhSach_SinhVien_LopHocPhans.FindAsync(id_LopHocPhan, id_SinhVien);

            if (record == null)
            {
                throw new QuanLySinhVien_Exceptions($"Không thể tìm thấy");
            }

            record.Diem = request.Diem;

            return await _context.SaveChangesAsync();
        }
    }
}
