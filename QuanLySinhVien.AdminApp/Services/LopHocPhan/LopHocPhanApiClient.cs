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
using QuanLySinhVien.ViewModel.Catalog.LopHocPhans;
using QuanLySinhVien.ViewModel.Common;
using QuanLySinhVien.ViewModel.Constants;

namespace QuanLySinhVien.AdminApp.Services.LopHocPhan
{
    public class LopHocPhanApiClient : ILopHocPhanApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LopHocPhanApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> Create(LopHocPhanCreateRequest request)
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

            var response = await client.PostAsync($"/api/lophocphans/", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(string id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.DeleteAsync($"/api/lophocphans/{id}");

            return response.IsSuccessStatusCode;
        }

        public async Task<PagedResult<LopHocPhanViewModel>> GetAllPaging(LopHocPhanManagePagingRequest request)
        {
            var sessions = _httpContextAccessor
                            .HttpContext
                            .Session
                            .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.GetAsync(
                $"/api/lophocphans/paging?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&keyword={request.Keyword}"
                );

            var body = await response.Content.ReadAsStringAsync();
            var lopHocPhan = JsonConvert.DeserializeObject<PagedResult<LopHocPhanViewModel>>(body);

            return lopHocPhan;
        }

        public Task<LopHocPhanViewModel> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<LopHocPhanViewModel>> GetSchedule(int hocky, int namhoc)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Schedule(int hocky, int namhoc, ScheduleCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(string id, LopHocPhanUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
