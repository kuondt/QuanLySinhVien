using QuanLySinhVien.Data.EF;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.ViewModel.Catalog.LopBienChes;
using QuanLySinhVien.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien.ViewModel.Exceptions;
using Microsoft.EntityFrameworkCore.Internal;

namespace QuanLySinhVien.Service.Catalog.LopBienChes
{
    public class LopBienCheService : ILopBienCheService
    {
        private readonly QLSV_DBContext _context;
        public LopBienCheService(QLSV_DBContext context)
        {
            _context = context;
        }

        public async Task<string> Create(LopBienCheCreateRequest request)
        {
            //STT lớp biên chế mặc định là 1
            //STT lớp biên chế = số thứ tự cuối cùng của lớp năm được tạo + 1
            int soThuTu_LopBienChe = 1;
            var sttCuoiCung_LopBienChe_CuaNam = _context.LopBienChes
                                            .Where(x => x.NamBatDau == request.NamBatDau)
                                            .Select(x => x.SoThuTu)
                                            .ToArray()
                                            .LastOrDefault();
            soThuTu_LopBienChe += sttCuoiCung_LopBienChe_CuaNam;

            //Lấy năm hiện tại
            string year = request.NamBatDau.ToString();
            //Lấy 2 số cuối của năm
            string lastTwoDigitsOfYear = year.Substring(year.Length - 2);

            //Ghép chuỗi tạo ID
            string ID_LopBienChe = lastTwoDigitsOfYear + "1A01" + soThuTu_LopBienChe.ToString().PadLeft(2, '0');

            var LopBienChe = new LopBienChe()
            {
                ID = ID_LopBienChe,
                SoThuTu = soThuTu_LopBienChe,
                NamBatDau = request.NamBatDau,
                NamKetThuc = request.NamBatDau + 4,
                ID_GiangVien = request.ID_GiangVien,
                ID_Khoa = request.ID_Khoa,
            };
            _context.LopBienChes.Add(LopBienChe);
            await _context.SaveChangesAsync();
            return LopBienChe.ID;
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

        public async Task<LopBienCheViewModel> GetById(string id)
        {
            var lopBienChe = await _context.LopBienChes.FindAsync(id);

            if (lopBienChe == null)
            {
                throw new QuanLySinhVien_Exceptions($"Không thể tìm thấy: {id}");
            }

            //var sinhViens = from sv in _context.SinhViens
            //                where sv.ID_LopBienChe == id
            //                select sv;
            var sinhViens = _context.SinhViens
                        .Where(x => x.ID_LopBienChe == id)
                        .OrderBy(x => x.ID);
            var listSinhVien = sinhViens.ToList();

            var giangVien = _context.GiangViens
                        .Where(x => x.ID == lopBienChe.ID_GiangVien)
                        .FirstOrDefault();



            var lopBienCheViewModel = new LopBienCheViewModel()
            {
                ID = lopBienChe.ID,
                SoThuTu = lopBienChe.SoThuTu,
                NamBatDau = lopBienChe.NamBatDau,
                NamKetThuc = lopBienChe.NamKetThuc,
                ID_Khoa = lopBienChe.ID_Khoa,
                ID_GiangVien = lopBienChe.ID_GiangVien,
                GiangVien = giangVien,
                SinhViens = listSinhVien
            };
            return lopBienCheViewModel;
        }

        public async Task<int> Update(string id, LopBienCheUpdateRequest request)
        {
            var lopBienChe = await _context.LopBienChes.FindAsync(id);

            if (lopBienChe == null)
            {
                throw new QuanLySinhVien_Exceptions($"Không thể tìm thấy: {id}");
            }

            lopBienChe.ID_GiangVien = request.ID_GiangVien;

            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(string id)
        {
            var lopBienChe = await _context.LopBienChes.FindAsync(id);

            //Lấy danh sách sv và tìm sinh viên trong LBC
            var query = from sv
                         in _context.SinhViens
                        select new { sv };
            var sinhVien = query.Any(x => x.sv.ID_LopBienChe.Contains(id));

            if (lopBienChe == null)
            {
                throw new QuanLySinhVien_Exceptions($"Không thể tìm thấy: {id}");
            }

            //Nếu ko có sv nào thuộc LBC thì có thể xóa LBC
            if (!sinhVien)
            {
                _context.LopBienChes.Remove(lopBienChe);
                return await _context.SaveChangesAsync();
            }
            else
            {
                throw new QuanLySinhVien_Exceptions($"Không thể xóa: {id}");
            }

        }
    }
}
