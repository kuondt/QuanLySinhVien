using QuanLySinhVien.ViewModel.Catalog.MonHocs;
using QuanLySinhVien.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Service.Catalog.MonHocs
{
    public interface IMonHoc_Service
    {
        Task<string> Create(MonHocCreateRequest request);

        Task<MonHocViewModel> GetById(string id);

        Task<int> Update(string id, MonHocUpdateRequest request);

        Task<PagedResult<MonHocViewModel>> GetAllPaging(MonHocManagePagingRequest request);
    }
}
