using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Data.Entities
{
    public class GiangVien
    {
        public string ID { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string ID_Khoa { get; set; }
        public bool IsActive { get; set; }
    }
}
