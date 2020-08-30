using QuanLySinhVien.ViewModel.Catalog.LopBienChes;
using QuanLySinhVien.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLySinhVien.AdminApp.Services.LopBienChe
{
    public interface ILopBienCheApiClient
    {
        Task<bool> Create(LopBienCheCreateRequest request);

        Task<LopBienCheViewModel> GetById(string id);

        Task<bool> Update(string id, LopBienCheUpdateRequest request);

        Task<PagedResult<LopBienCheViewModel>> GetAllPaging(LopBienCheManagePagingRequest request);

        Task<bool> Delete(string id);
    }
}
