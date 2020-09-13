using System;
using System.Collections.Generic;
using System.Text;
using QuanLySinhVien.Data.Enums;

namespace QuanLySinhVien.ViewModel.Catalog.NgayHocBuoiHocs
{
    public class NgayHocBuoiHocViewModel
    {
        public BuoiHoc BuoiHoc { get; set; }
        public NgayHoc NgayHoc { get; set; }
        public string ID_GiangVien { get; set; }
        public string ID_Phong { get; set; }
        public string ID_LopHocPhan { get; set; }
    }
}
