using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien.ViewModel.Catalog.ChiTietChuongTrinhDaoTaos;
using QuanLySinhVien.ViewModel.Common;

namespace QuanLySinhVien.Service.Catalog.ChiTietChuongTrinhDaoTaos
{
    public interface IChiTietChuongTrinhDaoTaoService
    {
        Task<string> Create(ChiTietChuongTrinhDaoTaoCreateRequest request);

        Task<int> Update(string id, ChiTietChuongTrinhDaoTaoUpdateRequest request);

        Task<ChiTietChuongTrinhDaoTaoViewModel> GetById(string id);

        Task<PagedResult<ChiTietChuongTrinhDaoTaoViewModel>> GetAllPaging(ChiTietChuongTrinhDaoTaoPagingRequest request);

        Task<int> Delete(string id);
    }
}
