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

        Task<ChiTietChuongTrinhDaoTaoViewModel> GetById(string ctdt, string monhoc);

        Task<bool> Update(string ctdt, string monhoc, ChiTietChuongTrinhDaoTaoUpdateRequest request);

        Task<PagedResult<ChiTietChuongTrinhDaoTaoViewModel>> GetAllByIdChuongTrinhDaoTao(ChiTietChuongTrinhDaoTaoPagingRequest request);

        Task<bool> Delete(string ctdt, string monhoc);
    }
}
