using QuanLySinhVien.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.ViewModel.Catalog.Phongs
{
    public class PhongManagePagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }   
}
