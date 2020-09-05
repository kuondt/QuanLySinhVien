using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLySinhVien.ViewModel.Catalog.ChiTietChuongTrinhDaoTaos;
using QuanLySinhVien.ViewModel.Common;

namespace QuanLySinhVien.AdminApp.Services.ChiTietChuongTrinhDaoTao
{
    public class ChiTietChuongTrinhDaoTaoApiClient : IChiTietChuongTrinhDaoTaoApiClient
    {
        public Task<bool> Create(ChiTietChuongTrinhDaoTaoCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<ChiTietChuongTrinhDaoTaoViewModel>> GetAllPaging(ChiTietChuongTrinhDaoTaoPagingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ChiTietChuongTrinhDaoTaoViewModel> GetById(string id_CTDT, string id_MonHoc, int hocKy, int namHoc)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(string id_CTDT, string id_MonHoc, int hocKy, int namHoc, ChiTietChuongTrinhDaoTaoUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
