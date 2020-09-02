using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien.ViewModel.Catalog.HocKyNamHocs;
using QuanLySinhVien.ViewModel.Common;

namespace QuanLySinhVien.Service.Catalog.HocKyNamHocs
{
    public interface IHocKyNamHocService
    {
        Task<Tuple<int, int>> Create(HocKyNamHocCreateRequest request);

        Task<int> Update(int hocky, int namhoc, HocKyNamHocUpdateRequest request);

        Task<HocKyNamHocViewModel> GetById(int hocky, int namhoc);

        Task<PagedResult<HocKyNamHocViewModel>> GetAllPaging(HocKyNamHocManagePagingRequest request);
    }
}
