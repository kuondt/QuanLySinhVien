using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Data.Entities
{
    public class MonHoc
    {
        public string ID { get; set; }
        public string TenMonHoc { get; set; }
        public int SoTiet { get; set; }
        public int SoTinChi { get; set; }
        public string Id_Khoa { get; set; }

    }
}
