﻿using System;
using System.Collections.Generic;
using System.Text;
using QuanLySinhVien.ViewModel.Common;

namespace QuanLySinhVien.ViewModel.Catalog.HocKyNamHocs
{
    public class HocKyMangePagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
