using QuanLySinhVien.ViewModel.Catalog.GiangViens;
using QuanLySinhVien.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLySinhVien.AdminApp.Services.GiangVien
{
    public interface IGiangVienApiClient 
    {
        Task<bool> Create(GiangVienCreateRequest request);

        Task<GiangVienViewModel> GetById(string id);

        Task<bool> Update(string id, GiangVienUpdateRequest request);

        Task<PagedResult<GiangVienViewModel>> GetAllPaging(GiangVienManagePagingRequest request);
    }
}
