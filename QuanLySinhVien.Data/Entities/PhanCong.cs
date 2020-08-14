using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Data.Entities
{
    public class PhanCong
    {
        public string ID_GiangVien { get; set; }
        public string ID_LopHocPhan { get; set; }
        public GiangVien GiangVien { get; set; }
        public LopHocPhan LopHocPhan { get; set; }
    }
}
