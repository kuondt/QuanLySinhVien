using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLySinhVien.ViewModel.Catalog.DanhSachSinhViens;
using QuanLySinhVien.ViewModel.Common;

namespace QuanLySinhVien.AdminApp.Services.DanhSachSinhVien
{
    public class DanhSachSinhVienApiClient : IDanhSachSinhVienApiClient
    {
        public Task<bool> Create(DanhSachSinhVienCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string lophocphan, string sinhvien)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<DanhSachSinhVienViewModel>> GetAllByIdChuongTrinhDaoTao(DanhSachSinhVienPagingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<DanhSachSinhVienViewModel> GetById(string lophocphan, string sinhvien)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(string lophocphan, string sinhvien, DanhSachSinhVienUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
