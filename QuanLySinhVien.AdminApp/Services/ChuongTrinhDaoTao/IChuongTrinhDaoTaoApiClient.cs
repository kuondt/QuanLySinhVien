using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLySinhVien.ViewModel.Catalog.ChuongTrinhDaoTaos;
using QuanLySinhVien.ViewModel.Common;

namespace QuanLySinhVien.AdminApp.Services.ChuongTrinhDaoTao
{
    public interface IChuongTrinhDaoTaoApiClient
    {
        Task<bool> Create(ChuongTrinhDaoTaoCreateRequest request);

        Task<bool> Update(string id, ChuongTrinhDaoTaoUpdateRequest request);

        Task<ChuongTrinhDaoTaoViewModel> GetById(string id);

        Task<PagedResult<ChuongTrinhDaoTaoViewModel>> GetAllPaging(ChuongTrinhDaoTaoPagingRequest request);
    }
}
