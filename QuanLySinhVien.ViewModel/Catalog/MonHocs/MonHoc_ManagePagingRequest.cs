using QuanLySinhVien.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.ViewModel.Catalog.MonHocs
{
    public class MonHoc_ManagePagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
