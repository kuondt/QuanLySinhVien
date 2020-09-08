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
        Task<Tuple<string, string>> Create(ChiTietChuongTrinhDaoTaoCreateRequest request);

        Task<int> Update(string id_CTDT, string id_MonHoc, ChiTietChuongTrinhDaoTaoUpdateRequest request);

        Task<ChiTietChuongTrinhDaoTaoViewModel> GetById(string id_CTDT, string id_MonHoc);

        Task<PagedResult<ChiTietChuongTrinhDaoTaoViewModel>> GetAllByIdChuongTrinhDaoTao(ChiTietChuongTrinhDaoTaoPagingRequest request);

        Task<int> Delete(string id_CTDT, string id_MonHoc);
    }
}
