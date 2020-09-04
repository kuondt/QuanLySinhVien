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

namespace QuanLySinhVien.Service.Catalog.ChiTietChuongTrinhDaoTaos
{
    public class ChiTietChuongTrinhDaoTaoService : IChiTietChuongTrinhDaoTaoService
    {
        private readonly QLSV_DBContext _context;

        public ChiTietChuongTrinhDaoTaoService(QLSV_DBContext context)
        {
            _context = context;
        }

        public async Task<Tuple<string, string, int, int>> Create(ChiTietChuongTrinhDaoTaoCreateRequest request)
        {        
            var chiTiet_CTDT = new ChiTiet_ChuongTrinhDaoTao_MonHoc()
            {
               ID_ChuongTrinhDaoTao = request.ID_ChuongTrinhDaoTao,
               ID_MonHoc = request.ID_MonHoc,
               HK_HocKy = request.HK_HocKy,
               HK_NamHoc = request.HK_NamHoc               
            };

            _context.ChiTiet_ChuongTrinhDaoTao_MonHocs.Add(chiTiet_CTDT);
            await _context.SaveChangesAsync();

            return Tuple.Create(chiTiet_CTDT.ID_ChuongTrinhDaoTao, chiTiet_CTDT.ID_MonHoc, chiTiet_CTDT.HK_HocKy, chiTiet_CTDT.HK_NamHoc);
        }

        public Task<int> Delete(string id_MonHoc, string id_CTDT, int hocKy, int nam)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResult<ChiTietChuongTrinhDaoTaoViewModel>> GetAllPaging(ChiTietChuongTrinhDaoTaoPagingRequest request)
        {
            var query = from ct_ctdt
                        in _context.ChiTiet_ChuongTrinhDaoTao_MonHocs
                        orderby ct_ctdt.HK_NamHoc, ct_ctdt.HK_HocKy
                        select new { ct_ctdt };

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => 
                    x.ct_ctdt.HK_NamHoc.ToString().Contains(request.Keyword) 
                ||  x.ct_ctdt.HK_HocKy.ToString().Contains(request.Keyword) 
                ||  x.ct_ctdt.ID_MonHoc.ToString().Contains(request.Keyword)
                ||  x.ct_ctdt.ID_ChuongTrinhDaoTao.ToString().Contains(request.Keyword));
            }

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ChiTietChuongTrinhDaoTaoViewModel()
                {
                    HK_HocKy = x.ct_ctdt.HK_HocKy,
                    HK_NamHoc = x.ct_ctdt.HK_NamHoc,
                    ID_ChuongTrinhDaoTao = x.ct_ctdt.ID_ChuongTrinhDaoTao,
                    ID_MonHoc = x.ct_ctdt.ID_MonHoc

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

        public Task<ChiTietChuongTrinhDaoTaoViewModel> GetById(string id_MonHoc, string id_CTDT, int hocKy, int nam)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(string id_MonHoc, string id_CTDT, int hocKy, int nam, ChiTietChuongTrinhDaoTaoUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
