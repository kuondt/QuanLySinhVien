using QuanLySinhVien.ViewModel.Catalog.GiangViens;
using QuanLySinhVien.ViewModel.Catalog.MonHocs;
using QuanLySinhVien.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Service.Catalog.GiangViens
{
    public interface IGiangVienService
    {
        Task<string> Create(GiangVienCreateRequest request);

        Task<int> Update(string id, GiangVienUpdateRequest request);

        Task<GiangVienViewModel> GetById(string id);

        Task<PagedResult<GiangVienViewModel>> GetAllPaging(GiangVienManagePagingRequest request);

        //Task<int> IsActiveUpdate(string id);
    }
}
