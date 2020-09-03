using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLySinhVien.ViewModel.Catalog.HocKyNamHocs;
using QuanLySinhVien.ViewModel.Common;

namespace QuanLySinhVien.AdminApp.Services.HocKyNamHoc
{
    public interface IHocKyNamHocApiClient
    {
        Task<bool> Create(HocKyNamHocCreateRequest request);

        Task<HocKyNamHocViewModel> GetById(int hocky, int namhoc);

        Task<bool> Update(int hocky, int namhoc, HocKyNamHocUpdateRequest request);

        Task<PagedResult<HocKyNamHocViewModel>> GetAllPaging(HocKyNamHocManagePagingRequest request);
    }
}
