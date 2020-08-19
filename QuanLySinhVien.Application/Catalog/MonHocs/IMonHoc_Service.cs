using QuanLySinhVien.ViewModel.Catalog.MonHocs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Service.Catalog.MonHocs
{
    public interface IMonHoc_Service
    {
        Task<string> Create(MonHoc_CreateRequest request);

        Task<int> Update(MonHoc_UpdateRequest request);

        Task<MonHoc_ViewModel> GetById(string ID_MonHoc);

    }
}
