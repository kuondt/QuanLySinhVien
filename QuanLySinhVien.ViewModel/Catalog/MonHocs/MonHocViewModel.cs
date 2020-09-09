using System;
using System.Collections.Generic;
using System.Text;
using QuanLySinhVien.Data.Entities;

namespace QuanLySinhVien.ViewModel.Catalog.MonHocs
{
    public class MonHocViewModel
    {
        public string ID { get; set; }
        public int SoThuTu { get; set; }
        public string TenMonHoc { get; set; }
        public int SoTiet { get; set; }
        public int SoTinChi { get; set; }
        public string ID_Khoa { get; set; }
        public List<ChiTiet_ChuongTrinhDaoTao_MonHoc> ChiTiet_ChuongTrinhDaoTao_MonHocs { get; set; }
        public List<LopHocPhan> LopHocPhans { get; set; }
        public Khoa Khoa { get; set; }
        public List<ChuyenMon> ChuyenMons { get; set; }
    }
}
