using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.ViewModel.Common
{
    public class PagedResult<T> : PagedResultBase
    {
        public List<T> Items { get; set; }
    }
}
