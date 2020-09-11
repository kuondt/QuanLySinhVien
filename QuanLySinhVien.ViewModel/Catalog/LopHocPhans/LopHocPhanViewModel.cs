using System;
using System.Collections.Generic;
using System.Text;
using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.Data.Enums;

namespace QuanLySinhVien.ViewModel.Catalog.LopHocPhans
{
    public class LopHocPhanViewModel
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
        public GiangVien GiangVien { get; set; }
        public List<DanhSach_SinhVien_LopHocPhan> ChiTiet_SinhVien_LopHocPhans { get; set; }
        public HocKy_NamHoc HocKy_NamHoc { get; set; }
        public Phong Phong { get; set; }
        public MonHoc MonHoc { get; set; }
    }
}
