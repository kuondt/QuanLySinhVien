using System;
using System.Threading.Tasks;
using QuanLySinhVien.ViewModel.Catalog.Phongs;
using QuanLySinhVien.Data.EF;
using System.Linq;
using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.ViewModel.Common;
using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.ViewModel.Exceptions;

namespace QuanLySinhVien.Service.Catalog.Phongs
{
    public class PhongService : IPhongService
    {
        private readonly QLSV_DBContext _context;

        public PhongService(QLSV_DBContext context)
        {
            _context = context;
        }

        public async Task<string> Create(PhongCreateRequest request)
        {
            //STT mặc định là 1
            //STT = số thứ tự cuối cùng + 1
            int soThuTu_Phong = 1;
            var sttCuoiCung_Phong = _context.Phongs
                                            .Select(x => x.SoThuTu)
                                            .ToArray()
                                            .LastOrDefault();
            soThuTu_Phong += sttCuoiCung_Phong;

            //Ghép chuỗi tạo ID
            string ID_Phong = "PH" + soThuTu_Phong.ToString().PadLeft(3, '0');

            var phong = new Phong()
            {
                ID = ID_Phong,
                SoThuTu = soThuTu_Phong,
                TenCoSo = request.TenCoSo
            };

            _context.Phongs.Add(phong);
            await _context.SaveChangesAsync();

            return phong.ID;
        }

        public async Task<PagedResult<PhongViewModel>> GetAllPaging(PhongManagePagingRequest request)
        {
            var query = from phong
                        in _context.Phongs
                        select new { phong };

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.phong.ID.Contains(request.Keyword));
            }

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new PhongViewModel()
                {
                    ID = x.phong.ID,
                    SoThuTu = x.phong.SoThuTu,
                    TenCoSo = x.phong.TenCoSo

                }).ToListAsync();

            var pagedResult = new PagedResult<PhongViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return pagedResult;
        }

        public async Task<PhongViewModel> GetById(string id)
        {
            var phong = await _context.Phongs.FindAsync(id);

            if (phong == null)
            {
                throw new QuanLySinhVien_Exceptions($"Không thể tìm thấy: {id}");
            }

            var phongViewModel = new PhongViewModel()
            {
                ID = phong.ID,
                SoThuTu = phong.SoThuTu,
                TenCoSo = phong.TenCoSo,
                
            };
            return phongViewModel;
        }

        public async Task<int> Update(string id, PhongUpdateRequest request)
        {
            var phong = await _context.Phongs.FindAsync(id);

            if (phong == null)
            {
                throw new QuanLySinhVien_Exceptions($"Không thể tìm thấy: {id}");
            }

            phong.TenCoSo = request.TenCoSo;

            return await _context.SaveChangesAsync();
        }
    }
}
