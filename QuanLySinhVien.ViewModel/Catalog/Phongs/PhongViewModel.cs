using QuanLySinhVien.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.ViewModel.Catalog.Phongs
{
    public class PhongViewModel
    {
        public string ID { get; set; }
        public string TenCoSo { get; set; }
        public int SoThuTu { get; set; }
        public List<LopHocPhan> LopHocPhans { get; set; }
    }
}
