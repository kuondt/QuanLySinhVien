using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.ViewModel.Catalog.HocKyNamHocs
{
    public class HocKyNamHocUpdateRequest
    {
        public int HocKy { get; set; }
        public int NamHoc { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
    }
}
