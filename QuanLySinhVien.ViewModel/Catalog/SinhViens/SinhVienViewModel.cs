using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuanLySinhVien.ViewModel.Catalog.SinhViens
{
    public class SinhVienViewModel
    {
        public string ID { get; set; }
        public int SoThuTu { get; set; }
        public int Nam { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string HoTen { get; set; }
        [DataType(DataType.Date)]
        public DateTime NgaySinh { get; set; }
        public GioiTinh GioiTinh { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string ID_LopBienChe { get; set; }
        public Status IsActive { get; set; }
        public LopBienChe LopBienChe { get; set; }
        public List<DanhSach_SinhVien_LopHocPhan> ChiTiet_SinhVien_LopHocPhans { get; set; }
        public string ID_ChuongTrinhDaoTao { get; set; }
        public ChuongTrinhDaoTao ChuongTrinhDaoTao { get; set; }

    }
}
