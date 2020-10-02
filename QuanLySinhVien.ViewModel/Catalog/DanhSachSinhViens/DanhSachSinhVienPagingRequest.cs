using System;
using System.Collections.Generic;
using System.Text;
using QuanLySinhVien.ViewModel.Common;

namespace QuanLySinhVien.ViewModel.Catalog.DanhSachSinhViens
{
    public class DanhSachSinhVienPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
