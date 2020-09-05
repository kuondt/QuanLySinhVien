using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLySinhVien.ViewModel.Catalog.ChiTietChuongTrinhDaoTaos;
using QuanLySinhVien.ViewModel.Common;

namespace QuanLySinhVien.AdminApp.Services.ChiTietChuongTrinhDaoTao
{
    public interface IChiTietChuongTrinhDaoTaoApiClient
    {
        Task<bool> Create(ChiTietChuongTrinhDaoTaoCreateRequest request);

        Task<ChiTietChuongTrinhDaoTaoViewModel> GetById(string id_CTDT, string id_MonHoc, int hocKy, int namHoc);

        Task<bool> Update(string id_CTDT, string id_MonHoc, int hocKy, int namHoc, ChiTietChuongTrinhDaoTaoUpdateRequest request);

        Task<PagedResult<ChiTietChuongTrinhDaoTaoViewModel>> GetAllPaging(ChiTietChuongTrinhDaoTaoPagingRequest request);
    }
}
