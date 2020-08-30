using QuanLySinhVien.ViewModel.Catalog.LopBienChe;
using QuanLySinhVien.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLySinhVien.AdminApp.Services.LopBienChe
{
    public class LopBienCheApiClient : ILopBienCheApiClient
    {
        public Task<bool> Create(LopBienCheCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<LopBienCheViewModel>> GetAllPaging(LopBienCheManagePagingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<LopBienCheViewModel> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(string id, LopBienCheUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
