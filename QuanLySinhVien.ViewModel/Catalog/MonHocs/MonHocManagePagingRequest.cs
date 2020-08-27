using QuanLySinhVien.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.ViewModel.Catalog.MonHocs
{
    public class MonHocManagePagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
