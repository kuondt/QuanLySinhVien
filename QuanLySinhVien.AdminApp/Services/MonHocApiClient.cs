using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using QuanLySinhVien.ViewModel.Catalog.MonHocs;
using QuanLySinhVien.ViewModel.Common;
using QuanLySinhVien.ViewModel.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.AdminApp.Services
{
    public class MonHocApiClient : BaseApiClient, IMonHocApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MonHocApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor) : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> Create(MonHoc_CreateRequest request)
        {
            var sessions = _httpContextAccessor
                .HttpContext
                .Session
                .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var jsonString = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");


            var response = await client.PostAsync($"/api/monhocs/", content);

                return response.IsSuccessStatusCode;

        }

        public async Task<PagedResult<MonHoc_ViewModel>> GetAllPaging(MonHoc_ManagePagingRequest request)
        {
            var monHocs = await GetAsync<PagedResult<MonHoc_ViewModel>>(
                $"/api/monhocs/paging?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&keyword={request.Keyword}");
            return monHocs;
        }

        public Task<MonHoc_ViewModel> GetById(string ID_MonHoc)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(MonHoc_UpdateRequest request)
        {
            throw new NotImplementedException();
        }

    }
}
