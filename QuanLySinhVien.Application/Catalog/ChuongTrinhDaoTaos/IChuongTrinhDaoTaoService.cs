using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien.ViewModel.Catalog.ChuongTrinhDaoTaos;
using QuanLySinhVien.ViewModel.Common;

namespace QuanLySinhVien.Service.Catalog.ChuongTrinhDaoTaos
{
    public interface IChuongTrinhDaoTaoService
    {
        Task<string> Create(ChuongTrinhDaoTaoCreateRequest request);

        Task<int> Update(string id, ChuongTrinhDaoTaoUpdateRequest request);

        Task<ChuongTrinhDaoTaoViewModel> GetById(string id);

        Task<PagedResult<ChuongTrinhDaoTaoViewModel>> GetAllPaging(ChuongTrinhDaoTaoPagingRequest request);
    }
}
