using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien.ViewModel.Catalog.ChuongTrinhDaoTaos;
using System.Linq;
using QuanLySinhVien.Data.EF;
using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.ViewModel.Common;
using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.ViewModel.Exceptions;
using QuanLySinhVien.Service.Catalog.ChiTietChuongTrinhDaoTaos;
using QuanLySinhVien.ViewModel.Catalog.ChiTietChuongTrinhDaoTaos;

namespace QuanLySinhVien.Service.Catalog.ChuongTrinhDaoTaos
{
    public class ChuongTrinhDaoTaoService : IChuongTrinhDaoTaoService
    {
        private readonly QLSV_DBContext _context;
        private readonly IChiTietChuongTrinhDaoTaoService _chiTietCTDT;

        public ChuongTrinhDaoTaoService(QLSV_DBContext context, IChiTietChuongTrinhDaoTaoService chiTietCTDT)
        {
            _context = context;
            _chiTietCTDT = chiTietCTDT;
        }

        public async Task<string> Create(ChuongTrinhDaoTaoCreateRequest request)
        {
            //STT mặc định là 1
            //STT = số thứ tự cuối cùng năm đó + 1
            int soThuTu = 1;
            var sttCuoiCung_CuaNam = _context.ChuongTrinhDaoTaos
                                                .Where(x => x.Nam == request.Nam)
                                                .Select(x => x.SoThuTu)
                                                .ToArray()
                                                .LastOrDefault();
            soThuTu += sttCuoiCung_CuaNam;

            //Lấy năm hiện tại
            string year = request.Nam.ToString();

            //Ghép chuỗi tạo ID
            string Id = year + "CNTT" + soThuTu.ToString().PadLeft(2, '0');

            var chuongTrinhDaoTao = new ChuongTrinhDaoTao()
            {
                ID = Id,
                SoThuTu = soThuTu,
                Nam = request.Nam,
                Id_Khoa = request.Id_Khoa ?? "CNTT",
                TenChuongTrinh = request.TenChuongTrinh

            };

            _context.ChuongTrinhDaoTaos.Add(chuongTrinhDaoTao);
            await _context.SaveChangesAsync();

            return chuongTrinhDaoTao.ID;
        }

        public async Task<PagedResult<ChuongTrinhDaoTaoViewModel>> GetAllPaging(ChuongTrinhDaoTaoPagingRequest request)
        {
            var query = from ctdt
                        in _context.ChuongTrinhDaoTaos
                        select new { ctdt };

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.ctdt.ID.Contains(request.Keyword) || x.ctdt.TenChuongTrinh.Contains(request.Keyword));
            }

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ChuongTrinhDaoTaoViewModel()
                {
                    ID = x.ctdt.ID,
                    SoThuTu = x.ctdt.SoThuTu,
                    Nam = x.ctdt.Nam,
                    TenChuongTrinh = x.ctdt.TenChuongTrinh,
                    Id_Khoa = x.ctdt.Id_Khoa

                }).ToListAsync();

            var pagedResult = new PagedResult<ChuongTrinhDaoTaoViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return pagedResult;
        }

        public async Task<ChuongTrinhDaoTaoViewModel> GetById(string id)
        {
            var chuongTrinhDaoTao = await _context.ChuongTrinhDaoTaos.FindAsync(id);

            if (chuongTrinhDaoTao == null)
            {
                throw new QuanLySinhVien_Exceptions($"Không thể tìm thấy: {id}");
            }



            var listChiTietCTDT = _context.ChiTiet_ChuongTrinhDaoTao_MonHocs
                                            .Where(x => x.ID_ChuongTrinhDaoTao == id)
                                            .ToList();


            var chuongTrinhDaoTaoViewModel = new ChuongTrinhDaoTaoViewModel()
            {
                ID = chuongTrinhDaoTao.ID,
                SoThuTu = chuongTrinhDaoTao.SoThuTu,
                TenChuongTrinh = chuongTrinhDaoTao.TenChuongTrinh,
                Nam = chuongTrinhDaoTao.Nam,
                Id_Khoa = chuongTrinhDaoTao.Id_Khoa,
                ChiTiet_ChuongTrinhDaoTao_MonHocs = listChiTietCTDT
            };
            return chuongTrinhDaoTaoViewModel;
        }

        public async Task<int> Update(string id, ChuongTrinhDaoTaoUpdateRequest request)
        {
            var ctdt = await _context.ChuongTrinhDaoTaos.FindAsync(id);

            if (ctdt == null)
            {
                throw new QuanLySinhVien_Exceptions($"Không thể tìm thấy: {id}");
            }

            ctdt.TenChuongTrinh = request.TenChuongTrinh;

            return await _context.SaveChangesAsync();
        }
    }
}
