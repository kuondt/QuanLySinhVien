using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Service.Catalog.DanhSachSinhViens
{
    public interface IDanhSachSinhVienService
    {
        Task<Tuple<string, string>> Create(DanhSachSinhVienCreateRequest request);

        Task<ChiTietChuongTrinhDaoTaoViewModel> GetById(string id_CTDT, string id_MonHoc);

        Task<PagedResult<ChiTietChuongTrinhDaoTaoViewModel>> GetAll(ChiTietChuongTrinhDaoTaoPagingRequest request);

        Task<int> Delete(string id_CTDT, string id_MonHoc);
    }
}
