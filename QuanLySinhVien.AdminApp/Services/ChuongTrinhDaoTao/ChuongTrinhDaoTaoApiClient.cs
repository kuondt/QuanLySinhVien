using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using QuanLySinhVien.ViewModel.Catalog.ChuongTrinhDaoTaos;
using QuanLySinhVien.ViewModel.Common;

namespace QuanLySinhVien.AdminApp.Services.ChuongTrinhDaoTao
{
    public class ChuongTrinhDaoTaoApiClient : IChuongTrinhDaoTaoApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ChuongTrinhDaoTaoApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public Task<string> Create(ChuongTrinhDaoTaoCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<ChuongTrinhDaoTaoViewModel>> GetAllPaging(ChuongTrinhDaoTaoPagingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ChuongTrinhDaoTaoViewModel> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(string id, ChuongTrinhDaoTaoUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
