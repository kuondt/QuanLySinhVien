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
using QuanLySinhVien.ViewModel.Catalog.ChiTietChuongTrinhDaoTaos;
using QuanLySinhVien.ViewModel.Common;
using QuanLySinhVien.ViewModel.Constants;

namespace QuanLySinhVien.AdminApp.Services.ChiTietChuongTrinhDaoTao
{
    public class ChiTietChuongTrinhDaoTaoApiClient : IChiTietChuongTrinhDaoTaoApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ChiTietChuongTrinhDaoTaoApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> Create(ChiTietChuongTrinhDaoTaoCreateRequest request)
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

            var response = await client.PostAsync($"/api/chitietchuongtrinhdaotaos/", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(string idctdt, string idmonhoc)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.DeleteAsync($"/api/chitietchuongtrinhdaotaos/{idctdt}/{idmonhoc}");

            return response.IsSuccessStatusCode;
        }

        public async Task<PagedResult<ChiTietChuongTrinhDaoTaoViewModel>> GetAllByIdChuongTrinhDaoTao(ChiTietChuongTrinhDaoTaoPagingRequest request)
        {
            var sessions = _httpContextAccessor
                             .HttpContext
                             .Session
                             .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.GetAsync(
                $"/api/chitietchuongtrinhdaotaos/paging?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&keyword={request.Keyword}"
                );

            var body = await response.Content.ReadAsStringAsync();
            var chiTiet_CTDT = JsonConvert.DeserializeObject<PagedResult<ChiTietChuongTrinhDaoTaoViewModel>>(body);

            return chiTiet_CTDT;
        }

        public async Task<ChiTietChuongTrinhDaoTaoViewModel> GetById(string idctdt, string idmonhoc)
        {
            var sessions = _httpContextAccessor
                            .HttpContext
                            .Session
                            .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.GetAsync(
                $"/api/chitietchuongtrinhdaotaos/{idctdt}/{idmonhoc}/"
                );

            var body = await response.Content.ReadAsStringAsync();
            var chiTiet_CTDT = JsonConvert.DeserializeObject<ChiTietChuongTrinhDaoTaoViewModel>(body);

            return chiTiet_CTDT;
        }

        public async Task<bool> Update(string idctdt, string idmonhoc, ChiTietChuongTrinhDaoTaoUpdateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"/api/chitietchuongtrinhdaotaos/{idctdt}/{idmonhoc}", httpContent);

            return response.IsSuccessStatusCode;
        }
    }
}
