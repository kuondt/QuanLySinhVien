using QuanLySinhVien.ViewModel.Catalog.SinhViens;
using QuanLySinhVien.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Service.Catalog.SinhViens
{
    public interface ISinhVienService
    {
        Task<string> Create(SinhVienCreateRequest request);

        Task<int> Update(string id, SinhVienUpdateRequest request);

        Task<SinhVienViewModel> GetById(string id);

        Task<PagedResult<SinhVienViewModel>> GetAllPaging(SinhVienManagePagingRequest request);
    }
}
