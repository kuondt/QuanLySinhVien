using Newtonsoft.Json;
using QuanLySinhVien.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Data.Entities
{
    [JsonObject(IsReference = true)]
    public class SinhVien
    {
        public string ID { get; set; }
        public int SoThuTu { get; set; }
        public int Nam { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public GioiTinh GioiTinh { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string ID_LopBienChe { get; set; }
        public string ID_ChuongTrinhDaoTao { get; set; }
        public Status IsActive { get; set; }
        public LopBienChe LopBienChe { get; set; }
        public ChuongTrinhDaoTao ChuongTrinhDaoTao { get; set; }
        [JsonIgnore]
        public List<DanhSach_SinhVien_LopHocPhan> ChiTiet_SinhVien_LopHocPhans { get; set; }
    }
}
