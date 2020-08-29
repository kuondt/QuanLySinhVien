using QuanLySinhVien.Data.EF;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.ViewModel.Catalog.LopBienChe;
using QuanLySinhVien.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Service.Catalog.LopBienChes
{
    public class LopBienCheService : ILopBienCheService
    {
        private readonly QLSV_DBContext _context;
        public LopBienCheService(QLSV_DBContext context)
        {
            _context = context;
        }

        public Task<string> Create(LopBienCheCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResult<LopBienCheViewModel>> GetAllPaging(LopBienCheManagePagingRequest request)
        {
            var query = from lbc
                         in _context.LopBienChes
                        select new { lbc };

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.lbc.ID.Contains(request.Keyword));
            }

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new LopBienCheViewModel()
                {
                    ID = x.lbc.ID,
                    SoThuTu = x.lbc.SoThuTu,
                    NamBatDau = x.lbc.NamBatDau,
                    NamKetThuc = x.lbc.NamKetThuc,
                    ID_Khoa = x.lbc.ID_Khoa,
                    ID_GiangVien = x.lbc.ID_GiangVien
                }).ToListAsync();

            var pagedResult = new PagedResult<LopBienCheViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return pagedResult;
        }

        public Task<LopBienCheViewModel> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(string id, LopBienCheUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
