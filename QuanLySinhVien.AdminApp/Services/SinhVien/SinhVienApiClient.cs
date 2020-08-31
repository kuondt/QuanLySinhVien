using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using QuanLySinhVien.ViewModel.Catalog.SinhViens;
using QuanLySinhVien.ViewModel.Common;
using QuanLySinhVien.ViewModel.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.AdminApp.Services.SinhVien
{
    public class SinhVienApiClient : ISinhVienApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SinhVienApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> Create(SinhVienCreateRequest request)
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

            var response = await client.PostAsync($"/api/sinhviens/", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<PagedResult<SinhVienViewModel>> GetAllPaging(SinhVienManagePagingRequest request)
        {
            var sessions = _httpContextAccessor
                             .HttpContext
                             .Session
                             .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.GetAsync(
                $"/api/sinhviens/paging?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&keyword={request.Keyword}"
                );

            var body = await response.Content.ReadAsStringAsync();
            var sinhVien = JsonConvert.DeserializeObject<PagedResult<SinhVienViewModel>>(body);

            return sinhVien;
        }

        public async Task<SinhVienViewModel> GetById(string id)
        {
            var sessions = _httpContextAccessor
                            .HttpContext
                            .Session
                            .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.GetAsync(
                $"/api/sinhviens/{id}"
                );

            var body = await response.Content.ReadAsStringAsync();
            var sinhVien = JsonConvert.DeserializeObject<SinhVienViewModel>(body);

            return sinhVien;
        }

        public async Task<bool> Update(string id, SinhVienUpdateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"/api/sinhviens/{id}", httpContent);

            return response.IsSuccessStatusCode;
        }
    }
}
