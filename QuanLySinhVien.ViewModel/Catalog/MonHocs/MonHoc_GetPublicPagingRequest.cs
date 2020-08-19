using QuanLySinhVien.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.ViewModel.Catalog.MonHocs
{
    public class MonHoc_GetPublicPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
