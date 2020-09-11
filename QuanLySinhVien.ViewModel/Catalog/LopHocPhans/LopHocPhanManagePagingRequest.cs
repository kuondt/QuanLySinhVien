using System;
using System.Collections.Generic;
using System.Text;
using QuanLySinhVien.ViewModel.Common;

namespace QuanLySinhVien.ViewModel.Catalog.LopHocPhans
{
    class LopHocPhanManagePagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
