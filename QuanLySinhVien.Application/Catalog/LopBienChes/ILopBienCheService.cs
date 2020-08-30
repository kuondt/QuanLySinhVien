using QuanLySinhVien.ViewModel.Catalog.LopBienChes;
using QuanLySinhVien.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Service.Catalog.LopBienChes
{
    public interface ILopBienCheService
    {
        Task<string> Create(LopBienCheCreateRequest request);

        Task<int> Update(string id, LopBienCheUpdateRequest request);

        Task<LopBienCheViewModel> GetById(string id);

        Task<PagedResult<LopBienCheViewModel>> GetAllPaging(LopBienCheManagePagingRequest request);

        Task<int> Delete(string id);

    }
}
