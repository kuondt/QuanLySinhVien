﻿using QuanLySinhVien.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.ViewModel.Catalog.SinhViens
{
    public class SinhVienMangePagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
