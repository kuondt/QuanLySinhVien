using QuanLySinhVien.ViewModel.Catalog.SinhViens;
using QuanLySinhVien.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLySinhVien.AdminApp.Services.SinhVien
{
    public interface ISinhVienApiClient
    {
        Task<bool> Create(SinhVienCreateRequest request);

        Task<SinhVienViewModel> GetById(string id);

        Task<bool> Update(string id, SinhVienUpdateRequest request);

        Task<PagedResult<SinhVienViewModel>> GetAllPaging(SinhVienManagePagingRequest request);
    }
}
