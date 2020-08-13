using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Data.Entities
{
    public class LopHocPhan
    {
        public string ID { get; set; }
        public int HK_HocKy { get; set; }
        public int HK_NamHoc { get; set; }
        public string ID_MonHoc { get; set; }
        public string ID_Phong { get; set; }
        public string SoTietHoc { get; set; }
        public string SiSo { get; set; }
        public string IsActive { get; set; }
    }
}
