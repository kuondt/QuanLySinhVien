using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLySinhVien.ViewModel.Catalog.ChiTietChuongTrinhDaoTaos;
using QuanLySinhVien.ViewModel.Common;

namespace QuanLySinhVien.AdminApp.Services.ChiTietChuongTrinhDaoTao
{
    public interface IChiTietChuongTrinhDaoTaoApiService
    {
        Task<bool> Create(ChiTietChuongTrinhDaoTaoCreateRequest request);

        Task<ChiTietChuongTrinhDaoTaoViewModel> GetById(int hocky, int namhoc);

        Task<bool> Update(int hocky, int namhoc, ChiTietChuongTrinhDaoTaoUpdateRequest request);

        Task<PagedResult<ChiTietChuongTrinhDaoTaoViewModel>> GetAllPaging(ChiTietChuongTrinhDaoTaoPagingRequest request);
    }
}
