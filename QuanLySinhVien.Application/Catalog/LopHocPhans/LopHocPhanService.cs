using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien.ViewModel.Catalog.LopHocPhans;
using QuanLySinhVien.ViewModel.Common;

namespace QuanLySinhVien.Service.Catalog.LopHocPhans
{
    public class LopHocPhanService : ILopHocPhanService
    {
        public Task<string> Create(LopHocPhanCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<LopHocPhanViewModel>> GetAllPaging(LopHocPhanManagePagingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<LopHocPhanViewModel> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(string id, LopHocPhanUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
