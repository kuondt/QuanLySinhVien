using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.ViewModel.Catalog.MonHoc
{
    public class MonHoc_UpdatRequest
    {
        public string ID { get; set; }
        public string TenMonHoc { get; set; }
        public int SoTiet { get; set; }
        public int SoTinChi { get; set; }
    }
}
