using QuanLySinhVien.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.ViewModel.Catalog.GiangViens
{
    public class GiangVienManagePagingRequest: PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
