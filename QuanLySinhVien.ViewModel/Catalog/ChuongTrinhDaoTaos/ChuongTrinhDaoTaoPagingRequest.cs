using System;
using System.Collections.Generic;
using System.Text;
using QuanLySinhVien.ViewModel.Common;

namespace QuanLySinhVien.ViewModel.Catalog.ChuongTrinhDaoTaos
{
    public class ChuongTrinhDaoTaoPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
