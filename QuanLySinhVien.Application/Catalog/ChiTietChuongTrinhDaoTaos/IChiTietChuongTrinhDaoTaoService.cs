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
        Task<Tuple<string, string, int, int>> Create(ChiTietChuongTrinhDaoTaoCreateRequest request);

        Task<int> Update(string id_MonHoc, string id_CTDT, int hocKy, int nam, ChiTietChuongTrinhDaoTaoUpdateRequest request);

        Task<ChiTietChuongTrinhDaoTaoViewModel> GetById(string id_MonHoc, string id_CTDT, int hocKy, int nam);

        Task<PagedResult<ChiTietChuongTrinhDaoTaoViewModel>> GetAllPaging(ChiTietChuongTrinhDaoTaoPagingRequest request);

        Task<int> Delete(string id_MonHoc, string id_CTDT, int hocKy, int nam);
    }
}
