using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLySinhVien.ViewModel.Catalog.Phongs;
using QuanLySinhVien.ViewModel.Common;

namespace QuanLySinhVien.AdminApp.Services.Phong
{
    public interface IPhongApiClient
    {
        Task<bool> Create(PhongCreateRequest request);

        Task<PhongViewModel> GetById(string id);

        Task<bool> Update(string id, PhongUpdateRequest request);

        Task<PagedResult<PhongViewModel>> GetAllPaging(PhongManagePagingRequest request);
    }
}
