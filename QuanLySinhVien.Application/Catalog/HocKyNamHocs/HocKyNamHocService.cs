using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien.Data.EF;
using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.ViewModel.Catalog.HocKyNamHocs;
using System.Linq;
using QuanLySinhVien.ViewModel.Common;
using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.ViewModel.Exceptions;
using QuanLySinhVien.ViewModel.Catalog.Phongs;

namespace QuanLySinhVien.Service.Catalog.HocKyNamHocs
{
    public class HocKyNamHocService : IHocKyNamHocService
    {
        private readonly QLSV_DBContext _context;
        public HocKyNamHocService(QLSV_DBContext context)
        {
            _context = context;
        }


        public async Task<Tuple<int, int>> Create(HocKyNamHocCreateRequest request)
        {
            //Học kỳ mặc định là 1
            //Học kỳ tạo mới = Học kì cuối cùng của năm đó + 1
            int soThuTu_HocKy = 1;
            var sttCuoiCung_HocKy_CuaNam = _context.HocKy_NamHocs
                                            .Where(x => x.NamHoc == request.NamHoc)
                                            .Select(x => x.HocKy)
                                            .ToArray()
                                            .LastOrDefault();
            soThuTu_HocKy += sttCuoiCung_HocKy_CuaNam;

            if(soThuTu_HocKy > 3)
            {
                throw new QuanLySinhVien_Exceptions("Học kỳ không thể lớn hơn 3");
            }

            var hocKyNamHoc = new HocKy_NamHoc()
            {
                HocKy = soThuTu_HocKy,
                NamHoc = request.NamHoc,
                NgayBatDau = request.NgayBatDau,
                NgayKetThuc = request.NgayKetThuc
            };

            _context.HocKy_NamHocs.Add(hocKyNamHoc);
            await _context.SaveChangesAsync();

            //Tạo dữ liệu tuple để trả về 2 giá trị
            return Tuple.Create(hocKyNamHoc.HocKy, hocKyNamHoc.NamHoc);
        }

        public async Task<PagedResult<HocKyNamHocViewModel>> GetAllPaging(HocKyNamHocManagePagingRequest request)
        {
            var query = from hocKyNamHoc
                        in _context.HocKy_NamHocs
                        orderby hocKyNamHoc.NamHoc, hocKyNamHoc.HocKy
                        select new { hocKyNamHoc };

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.hocKyNamHoc.NamHoc.ToString().Contains(request.Keyword) || x.hocKyNamHoc.HocKy.ToString().Contains(request.Keyword));
            }

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new HocKyNamHocViewModel()
                {
                    HocKy = x.hocKyNamHoc.HocKy,
                    NamHoc = x.hocKyNamHoc.NamHoc,
                    NgayBatDau = x.hocKyNamHoc.NgayBatDau,
                    NgayKetThuc = x.hocKyNamHoc.NgayKetThuc

                }).ToListAsync();

            var pagedResult = new PagedResult<HocKyNamHocViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return pagedResult;
        }

        public async Task<HocKyNamHocViewModel> GetById(int hocky, int namhoc)
        {
            var hocKyNamHoc = await _context.HocKy_NamHocs.FindAsync(hocky, namhoc);

            if (hocKyNamHoc == null)
            {
                throw new QuanLySinhVien_Exceptions($"Không thể tìm thấy {hocky}, {namhoc}");
            }

            var hocKyNamHocViewModel = new HocKyNamHocViewModel()
            {
                HocKy = hocKyNamHoc.HocKy,
                NamHoc = hocKyNamHoc.NamHoc,
                NgayBatDau = hocKyNamHoc.NgayBatDau,
                NgayKetThuc = hocKyNamHoc.NgayKetThuc,
                LopHocPhans = hocKyNamHoc.LopHocPhans

            };
            return hocKyNamHocViewModel;
        }

        public async Task<int> Update(int hocky, int namhoc, HocKyNamHocUpdateRequest request)
        {
            var hocKyNamHoc = await _context.HocKy_NamHocs.FindAsync(hocky, namhoc);

            if (hocKyNamHoc == null)
            {
                throw new QuanLySinhVien_Exceptions($"Không thể tìm thấy {hocky}, {namhoc}");
            }

            hocKyNamHoc.NgayBatDau = request.NgayBatDau;
            hocKyNamHoc.NgayKetThuc = request.NgayKetThuc;

            return await _context.SaveChangesAsync();
        }
    }
}
