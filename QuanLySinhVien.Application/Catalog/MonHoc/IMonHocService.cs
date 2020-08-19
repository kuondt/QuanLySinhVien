using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Service.Catalog.MonHoc
{
    public interface IMonHocService
    {
        Task<int> Create(MonHoc_CreateRequest request);

    }
}
