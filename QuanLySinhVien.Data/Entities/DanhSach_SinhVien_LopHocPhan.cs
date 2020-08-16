using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Data.Entities
{
    public class DanhSach_SinhVien_LopHocPhan
    {
        public string ID_SinhVien { get; set; }
        public string ID_LopHocPhan { get; set; }
        public int LanThi { get; set; }
        public float Diem { get; set; }
        public SinhVien SinhVien { get; set; }
        public LopHocPhan LopHocPhan { get; set; }
    }
}
