using QuanLySinhVien.ViewModel.Catalog.Phongs;
using QuanLySinhVien.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Service.Catalog.Phongs
{
    public interface IPhongService
    {
        Task<string> Create(PhongCreateRequest request);

        Task<int> Update(string id, PhongUpdateRequest request);

        Task<PhongViewModel> GetById(string id);

        Task<PagedResult<PhongViewModel>> GetAllPaging(PhongManagePagingRequest request);
    }
}
