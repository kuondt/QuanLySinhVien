using System;
using System.Collections.Generic;
using System.Text;
using QuanLySinhVien.Data.Entities;

namespace QuanLySinhVien.ViewModel.Catalog.DanhSachSinhViens
{
    public class DanhSachSinhVienViewModel
    {
        public string ID_SinhVien { get; set; }
        public string ID_LopHocPhan { get; set; }
        public int LanThi { get; set; }
        public float Diem { get; set; }
        public SinhVien SinhVien { get; set; }
        public LopHocPhan LopHocPhan { get; set; }
    }
}
