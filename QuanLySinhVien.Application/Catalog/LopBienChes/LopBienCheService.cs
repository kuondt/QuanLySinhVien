using QuanLySinhVien.ViewModel.Catalog.LopBienChe;
using QuanLySinhVien.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Service.Catalog.LopBienChes
{
    public class LopBienCheService : ILopBienCheService
    {
        public Task<string> Create(LopBienCheCreateRequest request)
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

        public Task<int> Update(string id, LopBienCheUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
