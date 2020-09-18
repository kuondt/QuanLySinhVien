using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien.ViewModel.Catalog.LopHocPhans;
using QuanLySinhVien.ViewModel.Common;

namespace QuanLySinhVien.Service.Catalog.LopHocPhans
{
    public interface ILopHocPhanService
    {
        Task<string> Create(LopHocPhanCreateRequest request);

        Task<int> Update(string id, LopHocPhanUpdateRequest request);

        Task<LopHocPhanViewModel> GetById(string id);

        Task<PagedResult<LopHocPhanViewModel>> GetAllPaging(LopHocPhanManagePagingRequest request);

        Task<int> Delete(string id);

        Task<PagedResult<LopHocPhanViewModel>> GetSchedule(LopHocPhanManagePagingRequest request);

        Task<int> Schedule(ScheduleRequest request);
    }
}
