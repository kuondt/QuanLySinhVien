using System;
using System.Collections.Generic;
using System.Text;
using QuanLySinhVien.ViewModel.Common;

namespace QuanLySinhVien.ViewModel.Catalog.LopHocPhans
{
    public class LopHocPhanManagePagingRequest : PagingRequestBase
    {
        public int? HocKy { get; set; }
        public int? NamHoc { get; set; }
        public string Keyword { get; set; }
    }
}
