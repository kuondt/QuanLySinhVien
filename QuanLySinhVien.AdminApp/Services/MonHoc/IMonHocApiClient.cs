using QuanLySinhVien.ViewModel.Catalog.MonHocs;
using QuanLySinhVien.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLySinhVien.AdminApp.Services.MonHoc
{
    public interface IMonHocApiClient
    {
        Task<bool> Create(MonHocCreateRequest request);

        Task<MonHocViewModel> GetById(string id);

        Task<bool> Update(string id, MonHocUpdateRequest request);

        Task<PagedResult<MonHocViewModel>> GetAllPaging(MonHocManagePagingRequest request);
    }
}
