using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            string ID_LopHocPhan = namHoc_2SoCuoi + hocKy +"INT" + Id_MonHoc + soThuTu;

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

        public Task<int> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<LopHocPhanViewModel>> GetAllPaging(LopHocPhanManagePagingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<LopHocPhanViewModel> GetById(string id)
        {
            throw new NotImplementedException();
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
