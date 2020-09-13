using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.Data.EF;
using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.Data.Enums;
using QuanLySinhVien.ViewModel.Catalog.LopHocPhans;
using QuanLySinhVien.ViewModel.Common;
using QuanLySinhVien.ViewModel.Exceptions;

namespace QuanLySinhVien.Service.Catalog.LopHocPhans
{
    public class LopHocPhanService : ILopHocPhanService
    {
        private readonly QLSV_DBContext _context;

        public LopHocPhanService(QLSV_DBContext context)
        {
            _context = context;
        }

        public async Task<string> Create(LopHocPhanCreateRequest request)
        {
            //STT mặc định là 1
            //STT = số thứ tự cuối cùng học kì năm đó + 1
            int soThuTu = 1;
            var sttCuoiCung = _context.LopHocPhans
                                    .Where(x => x.HK_NamHoc == request.HK_NamHoc)
                                    .Where(x => x.HK_HocKy == request.HK_HocKy)
                                    .Select(x => x.SoThuTu)
                                    .ToArray()
                                    .LastOrDefault();
            soThuTu += sttCuoiCung;

            //Lấy năm hiện tại
            string namHoc = request.HK_NamHoc.ToString();
            //Lấy 2 số cuối của năm
            string namHoc_2SoCuoi = namHoc.Substring(namHoc.Length - 2);

            //Lấy học kỳ hiện tại
            string hocKy = request.HK_HocKy.ToString();

            //Lấy số thứ tự 
            soThuTu.ToString().PadLeft(3, '0');

            //Lấy ID môn học
            string Id_MonHoc = request.ID_MonHoc;

            //Ghép chuỗi tạo ID => 201INT00101
            string ID_LopHocPhan = namHoc_2SoCuoi + hocKy + "INT" + Id_MonHoc + soThuTu;

            var lopHocPhan = new LopHocPhan()
            {
                ID = ID_LopHocPhan,
                SoThuTu = soThuTu,
                ID_MonHoc = Id_MonHoc,
                ID_GiangVien = request.ID_GiangVien,
                IsActive = Status.Active,
                HK_HocKy = request.HK_HocKy,
                HK_NamHoc = request.HK_NamHoc,

            };

            _context.LopHocPhans.Add(lopHocPhan);
            await _context.SaveChangesAsync();

            return lopHocPhan.ID;
        }

        public async Task<int> Delete(string id)
        {
            var lopHocPhan = await _context.LopHocPhans.FindAsync(id);

            if (lopHocPhan == null)
            {
                throw new QuanLySinhVien_Exceptions($"Không thể tìm thấy: {id}");
            }

            _context.LopHocPhans.Remove(lopHocPhan);
            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<LopHocPhanViewModel>> GetAllPaging(LopHocPhanManagePagingRequest request)
        {
            var query = from lhp
                        in _context.LopHocPhans
                        select new { lhp };

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(
                    x => x.lhp.ID_GiangVien.Contains(request.Keyword)
                    || x.lhp.ID.Contains(request.Keyword)
                    || x.lhp.ID_MonHoc.Contains(request.Keyword));
            }

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new LopHocPhanViewModel()
                {
                    ID = x.lhp.ID,
                    BuoiHoc = x.lhp.BuoiHoc,
                    NgayHoc = x.lhp.NgayHoc,
                    ID_GiangVien = x.lhp.ID_GiangVien,
                    ID_MonHoc = x.lhp.ID_MonHoc,
                    ID_Phong = x.lhp.ID_Phong,
                    HK_HocKy = x.lhp.HK_HocKy,
                    HK_NamHoc = x.lhp.HK_NamHoc,

                }).ToListAsync();

            var pagedResult = new PagedResult<LopHocPhanViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return pagedResult;
        }

        public async Task<LopHocPhanViewModel> GetById(string id)
        {
            var lopHocPhan = await _context.LopHocPhans.FindAsync(id);

            if (lopHocPhan == null)
            {
                throw new QuanLySinhVien_Exceptions($"Không thể tìm thấy: {id}");
            }

            var lopHocPhanViewModel = new LopHocPhanViewModel()
            {
                ID = lopHocPhan.ID,
                BuoiHoc = lopHocPhan.BuoiHoc,
                NgayHoc = lopHocPhan.NgayHoc,
                ID_GiangVien = lopHocPhan.ID_GiangVien,
                ID_MonHoc = lopHocPhan.ID_MonHoc,
                ID_Phong = lopHocPhan.ID_Phong,
                HK_HocKy = lopHocPhan.HK_HocKy,
                HK_NamHoc = lopHocPhan.HK_NamHoc,

            };
            return lopHocPhanViewModel;
        }

        public async Task<PagedResult<LopHocPhanViewModel>> Schedule(int hocky, int namhoc, LopHocPhanManagePagingRequest request)
        {
            var query = from lhp
                        in _context.LopHocPhans
                        select new { lhp };


            query = query.Where(
                x => x.lhp.HK_HocKy.Equals(hocky)
                && x.lhp.HK_NamHoc.Equals(namhoc));
  

            int totalRow = await query.CountAsync();

            var data = await query
                .Select(x => new LopHocPhanViewModel()
                {
                    ID = x.lhp.ID,
                    BuoiHoc = x.lhp.BuoiHoc,
                    NgayHoc = x.lhp.NgayHoc,
                    ID_GiangVien = x.lhp.ID_GiangVien,
                    ID_MonHoc = x.lhp.ID_MonHoc,
                    ID_Phong = x.lhp.ID_Phong,
                    HK_HocKy = x.lhp.HK_HocKy,
                    HK_NamHoc = x.lhp.HK_NamHoc,

                }).ToListAsync();

            var pagedResult = new PagedResult<LopHocPhanViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = 1,
                PageSize = 1000,
                Items = data
            };
            return pagedResult;
        }

        public async Task<int> Update(string id, LopHocPhanUpdateRequest request)
        {
            var lopHocPhan = await _context.LopHocPhans.FindAsync(id);

            if (lopHocPhan == null)
            {
                throw new QuanLySinhVien_Exceptions($"Không thể tìm thấy: {id}");
            }

            lopHocPhan.BuoiHoc = request.BuoiHoc;
            lopHocPhan.NgayHoc = request.NgayHoc;
            lopHocPhan.ID_Phong = request.ID_Phong;
            lopHocPhan.ID_GiangVien = request.ID_GiangVien;


            return await _context.SaveChangesAsync();
        }
    }
}
