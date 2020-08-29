using QuanLySinhVien.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.ViewModel.Catalog.LopBienChe
{
    public class LopBienCheManagePagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
