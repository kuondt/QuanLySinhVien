using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien.Data.EF;
using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.ViewModel.Catalog.ChiTietChuongTrinhDaoTaos;
using QuanLySinhVien.ViewModel.Common;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.ViewModel.Exceptions;
using QuanLySinhVien.ViewModel.Catalog.MonHocs;

namespace QuanLySinhVien.Service.Catalog.ChiTietChuongTrinhDaoTaos
{
    public class ChiTietChuongTrinhDaoTaoService : IChiTietChuongTrinhDaoTaoService
    {
        private readonly QLSV_DBContext _context;

        public ChiTietChuongTrinhDaoTaoService(QLSV_DBContext context)
        {
            _context = context;
        }

        public async Task<Tuple<string, string>> Create(ChiTietChuongTrinhDaoTaoCreateRequest request)
        {
            var chiTiet_CTDT = new ChiTiet_ChuongTrinhDaoTao_MonHoc()
            {
                ID_ChuongTrinhDaoTao = request.ID_ChuongTrinhDaoTao,
                ID_MonHoc = request.ID_MonHoc,
                HocKyDuKien = request.HocKyDuKien,
                Nam = request.Nam
            };

            _context.ChiTiet_ChuongTrinhDaoTao_MonHocs.Add(chiTiet_CTDT);
            await _context.SaveChangesAsync();

            return Tuple.Create(chiTiet_CTDT.ID_ChuongTrinhDaoTao, chiTiet_CTDT.ID_MonHoc);
        }

        public async Task<int> Delete(string id_CTDT, string id_MonHoc)
        {
            var chiTiet_CTDT = await _context.ChiTiet_ChuongTrinhDaoTao_MonHocs.FindAsync(id_CTDT, id_MonHoc);


            if (chiTiet_CTDT == null)
            {
                throw new QuanLySinhVien_Exceptions($"Không thể tìm thấy");
            }

            _context.ChiTiet_ChuongTrinhDaoTao_MonHocs.Remove(chiTiet_CTDT);
            return await _context.SaveChangesAsync();

        }

        public async Task<PagedResult<ChiTietChuongTrinhDaoTaoViewModel>> GetAllByIdChuongTrinhDaoTao(ChiTietChuongTrinhDaoTaoPagingRequest request)
        {
            var query = from ct_ctdt in _context.ChiTiet_ChuongTrinhDaoTao_MonHocs
                        join mh in _context.MonHocs on ct_ctdt.ID_MonHoc equals mh.ID
                        orderby ct_ctdt.HocKyDuKien
                        select new { ct_ctdt, mh };

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.ct_ctdt.ID_ChuongTrinhDaoTao.Contains(request.Keyword));
            }

            int totalRow = await query.CountAsync();

            var chuongTrinhDaoTao = await _context.ChuongTrinhDaoTaos.FindAsync(request.Keyword);

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ChiTietChuongTrinhDaoTaoViewModel()
                {
                    ID_ChuongTrinhDaoTao = x.ct_ctdt.ID_ChuongTrinhDaoTao,
                    ID_MonHoc = x.ct_ctdt.ID_MonHoc,
                    ChuongTrinhDaoTao = chuongTrinhDaoTao,
                    MonHoc = x.mh,
                    HocKyDuKien = x.ct_ctdt.HocKyDuKien,
                    Nam = x.ct_ctdt.Nam
                }).ToListAsync();

            var pagedResult = new PagedResult<ChiTietChuongTrinhDaoTaoViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return pagedResult;
        }

        public async Task<ChiTietChuongTrinhDaoTaoViewModel> GetById(string id_CTDT, string id_MonHoc)
        {
            var chiTiet_CTDT = await _context.ChiTiet_ChuongTrinhDaoTao_MonHocs.FindAsync(id_CTDT, id_MonHoc);

            var monHoc = await _context.MonHocs.FindAsync(id_MonHoc);

            var chuongTrinhDaoTao = await _context.ChuongTrinhDaoTaos.FindAsync(id_CTDT);

            if (chiTiet_CTDT == null)
            {
                throw new QuanLySinhVien_Exceptions($"Không thể tìm thấy");
            }

            var hocKyNamHocViewModel = new ChiTietChuongTrinhDaoTaoViewModel()
            {

                ID_ChuongTrinhDaoTao = chiTiet_CTDT.ID_ChuongTrinhDaoTao,
                ID_MonHoc = chiTiet_CTDT.ID_MonHoc,
                MonHoc = monHoc,
                ChuongTrinhDaoTao = chuongTrinhDaoTao,
                HocKyDuKien = chiTiet_CTDT.HocKyDuKien,
                Nam = chiTiet_CTDT.Nam
            };
            return hocKyNamHocViewModel;
        }

        public async Task<int> Update(string id_CTDT, string id_MonHoc, ChiTietChuongTrinhDaoTaoUpdateRequest request)
        {
            var chiTiet_CTDT = await _context.ChiTiet_ChuongTrinhDaoTao_MonHocs.FindAsync(id_MonHoc, id_CTDT);

            if (chiTiet_CTDT == null)
            {
                throw new QuanLySinhVien_Exceptions($"Không thể tìm thấy");
            }

            chiTiet_CTDT.ID_MonHoc = request.ID_MonHoc ?? chiTiet_CTDT.ID_MonHoc;

            return await _context.SaveChangesAsync();
        }
    }
}
