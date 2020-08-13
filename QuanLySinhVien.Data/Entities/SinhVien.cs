using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Data.Entities
{
    public class SinhVien
    {
        public string ID { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string HoTen { get; set; }
        public string NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string ID_LopBienChe { get; set; }
        public bool IsActive { get; set; }
    }
}
