using System;
using System.Collections.Generic;
using System.Text;
using QuanLySinhVien.Data.Enums;

namespace QuanLySinhVien.ViewModel.Catalog.LopHocPhans
{
    public class LopHocPhanCreateRequest
    {
        public string ID { get; set; }
        public int SoThuTu { get; set; }
        public int HK_HocKy { get; set; }
        public int HK_NamHoc { get; set; }
        public string ID_MonHoc { get; set; }
        public string ID_Phong { get; set; }
        public string ID_GiangVien { get; set; }
        public BuoiHoc BuoiHoc { get; set; }
        public NgayHoc NgayHoc { get; set; }
        public Status IsActive { get; set; }
    }
}
