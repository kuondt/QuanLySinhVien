using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using QuanLySinhVien.ViewModel.Catalog.LopHocPhans;
using QuanLySinhVien.ViewModel.Common;

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

        public Task<bool> Create(LopHocPhanCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<LopHocPhanViewModel>> GetAllPaging(LopHocPhanManagePagingRequest request)
        {
            throw new NotImplementedException();
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
