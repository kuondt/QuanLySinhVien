using System;
using System.Collections.Generic;
using System.Text;
using QuanLySinhVien.Data.Entities;

namespace QuanLySinhVien.ViewModel.Catalog.ChuongTrinhDaoTaos
{
    public class ChuongTrinhDaoTaoViewModel
    {
        public string ID { get; set; }
        public string TenChuongTrinh { get; set; }
        public int SoThuTu { get; set; }
        public int Nam { get; set; }
        public string Id_Khoa { get; set; }
        public Khoa Khoa { get; set; }
        public List<ChiTiet_ChuongTrinhDaoTao_MonHoc> ChiTiet_ChuongTrinhDaoTao_MonHocs { get; set; }
        public List<SinhVien> SinhViens { get; set; }
    }
}
