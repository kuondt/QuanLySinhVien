using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien.Data.EF;
using QuanLySinhVien.ViewModel.Catalog.DanhSachSinhViens;
using QuanLySinhVien.ViewModel.Common;

namespace QuanLySinhVien.Service.Catalog.DanhSachSinhViens
{
    public class DanhSachSinhVienService : IDanhSachSinhVienService
    {
        private readonly QLSV_DBContext _context;

        public DanhSachSinhVienService(QLSV_DBContext context)
        {
            _context = context;
        }

        public Task<Tuple<string, string>> Create(DanhSachSinhVienCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(string id_LopHocPhan, string id_SinhVien)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<DanhSachSinhVienViewModel>> GetAll(DanhSachSinhVienPagingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<DanhSachSinhVienViewModel> GetById(string id_LopHocPhan, string id_SinhVien)
        {
            throw new NotImplementedException();
        }
    }
}
