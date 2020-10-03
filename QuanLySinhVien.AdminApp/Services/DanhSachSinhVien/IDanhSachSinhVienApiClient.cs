using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLySinhVien.ViewModel.Catalog.DanhSachSinhViens;
using QuanLySinhVien.ViewModel.Common;

namespace QuanLySinhVien.AdminApp.Services.DanhSachSinhVien
{
    public interface IDanhSachSinhVienApiClient
    {
        Task<bool> Create(DanhSachSinhVienCreateRequest request);

        Task<DanhSachSinhVienViewModel> GetById(string lophocphan, string sinhvien);

        Task<bool> Update(string lophocphan, string sinhvien, DanhSachSinhVienUpdateRequest request);

        Task<PagedResult<DanhSachSinhVienViewModel>> GetAllByIdLopHocPhan(DanhSachSinhVienPagingRequest request);

        Task<bool> Delete(string lophocphan, string sinhvien);
    }
}
