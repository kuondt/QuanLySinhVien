using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.ViewModel.Catalog.MonHocs
{
    public class MonHocUpdateRequest
    {
        public string ID { get; set; }
        public string TenMonHoc { get; set; }
        public int SoTinChi { get; set; }
    }
}
