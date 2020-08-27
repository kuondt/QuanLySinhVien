using QuanLySinhVien.ViewModel.Catalog.MonHocs;
using QuanLySinhVien.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLySinhVien.AdminApp.Services
{
    public interface IMonHocApiClient
    {
        Task<bool> Create(MonHoc_CreateRequest request);

        Task<MonHoc_ViewModel> GetById(string ID_MonHoc);

        Task<int> Update(MonHoc_UpdateRequest request);

        Task<PagedResult<MonHoc_ViewModel>> GetAllPaging(MonHoc_ManagePagingRequest request);
    }
}
