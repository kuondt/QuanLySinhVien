using System;
using System.Threading.Tasks;
using QuanLySinhVien.ViewModel.Catalog.Phongs;
using QuanLySinhVien.Data.EF;
using System.Linq;
using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.ViewModel.Common;

namespace QuanLyPhong.Service.Catalog.Phongs
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
            //STT = số thứ tự cuối cùng của năm đó + 1
            int soThuTu_Phong = 1;
            var sttCuoiCung_Phong_CuaNam = _context.Phongs
                                                .Select(x => x.SoThuTu)
                                                .ToArray()
                                                .LastOrDefault();
            soThuTu_Phong += sttCuoiCung_Phong_CuaNam;


            //Ghép chuỗi tạo ID
            string ID_Phong =  "PH" + soThuTu_Phong.ToString().PadLeft(3, '0');

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

        public Task<PagedResult<PhongViewModel>> GetAllPaging(PhongManagePagingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PhongViewModel> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(string id, PhongUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
