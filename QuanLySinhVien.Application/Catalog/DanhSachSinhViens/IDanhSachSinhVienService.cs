using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien.ViewModel.Catalog.DanhSachSinhViens;
using QuanLySinhVien.ViewModel.Common;

namespace QuanLySinhVien.Service.Catalog.DanhSachSinhViens
{
    public interface IDanhSachSinhVienService
    {
        Task<Tuple<string, string>> Create(DanhSachSinhVienCreateRequest request);

        Task<DanhSachSinhVienViewModel> GetById(string id_LopHocPhan, string id_SinhVien);

        Task<PagedResult<DanhSachSinhVienViewModel>> GetAll(DanhSachSinhVienPagingRequest request);

        Task<int> Delete(string id_LopHocPhan, string id_SinhVien);
    }
}
