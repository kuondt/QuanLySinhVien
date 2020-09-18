using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLySinhVien.ViewModel.Catalog.LopHocPhans;
using QuanLySinhVien.ViewModel.Common;

namespace QuanLySinhVien.AdminApp.Services.LopHocPhan
{
    public interface ILopHocPhanApiClient
    {
        Task<bool> Create(LopHocPhanCreateRequest request);

        Task<bool> Update(string id, LopHocPhanUpdateRequest request);

        Task<LopHocPhanViewModel> GetById(string id);

        Task<PagedResult<LopHocPhanViewModel>> GetAllPaging(LopHocPhanManagePagingRequest request);

        Task<bool> Delete(string id);

        Task<PagedResult<LopHocPhanViewModel>> GetSchedule(LopHocPhanManagePagingRequest request);

        Task<bool> Schedule(ScheduleRequest request);
    }
}
