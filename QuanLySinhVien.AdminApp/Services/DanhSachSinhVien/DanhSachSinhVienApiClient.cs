using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using QuanLySinhVien.ViewModel.Catalog.DanhSachSinhViens;
using QuanLySinhVien.ViewModel.Common;
using QuanLySinhVien.ViewModel.Constants;

namespace QuanLySinhVien.AdminApp.Services.DanhSachSinhVien
{
    public class DanhSachSinhVienApiClient : IDanhSachSinhVienApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DanhSachSinhVienApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> Create(DanhSachSinhVienCreateRequest request)
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

            var response = await client.PostAsync($"/api/danhsachsinhviens/", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(string lophocphan, string sinhvien)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.DeleteAsync($"/api/danhsachsinhviens/{lophocphan}/{sinhvien}");

            return response.IsSuccessStatusCode;
        }

        public async Task<PagedResult<DanhSachSinhVienViewModel>> GetAllByIdLopHocPhan(DanhSachSinhVienPagingRequest request)
        {
            var sessions = _httpContextAccessor
                             .HttpContext
                             .Session
                             .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.GetAsync(
                $"/api/danhsachsinhviens/paging?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&keyword={request.Keyword}"
                );

            var body = await response.Content.ReadAsStringAsync();
            var danhSachSinhVien = JsonConvert.DeserializeObject<PagedResult<DanhSachSinhVienViewModel>>(body);

            return danhSachSinhVien;
        }

        public async Task<DanhSachSinhVienViewModel> GetById(string lophocphan, string sinhvien)
        {
            var sessions = _httpContextAccessor
                            .HttpContext
                            .Session
                            .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.GetAsync(
                $"/api/danhsachsinhviens/{lophocphan}/{sinhvien}/"
                );

            var body = await response.Content.ReadAsStringAsync();
            var danhSachSinhVien = JsonConvert.DeserializeObject<DanhSachSinhVienViewModel>(body);

            return danhSachSinhVien;
        }

        public async Task<bool> Update(string lophocphan, string sinhvien, DanhSachSinhVienUpdateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"/api/danhsachsinhviens/{lophocphan}/{sinhvien}", httpContent);

            return response.IsSuccessStatusCode;
        }
    }
}
