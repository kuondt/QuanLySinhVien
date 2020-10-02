using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.ViewModel.Catalog.DanhSachSinhViens
{
    public class DanhSachSinhVienCreateRequest
    {
        public string ID_SinhVien { get; set; }
        public string ID_LopHocPhan { get; set; }
        public int LanThi { get; set; }
        public float Diem { get; set; }
    }
}
