using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using QuanLySinhVien.ViewModel.Catalog.GiangViens;
using QuanLySinhVien.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace QuanLySinhVien.AdminApp.Services.GiangVien
{
    public class GiangVienApiClient : BaseApiClient, IGiangVienApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GiangVienApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor) : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public Task<bool> Create(GiangVienCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResult<GiangVienViewModel>> GetAllPaging(GiangVienManagePagingRequest request)
        {
            var giangViens = await GetAsync<PagedResult<GiangVienViewModel>>(
                $"/api/giangviens/paging?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&keyword={request.Keyword}");
            return giangViens;
        }

        public Task<GiangVienViewModel> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(string id, GiangVienUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
