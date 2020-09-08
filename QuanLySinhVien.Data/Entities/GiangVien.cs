using Newtonsoft.Json;
using QuanLySinhVien.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Data.Entities
{
    [JsonObject(IsReference = true)]
    public class GiangVien
    {
        public string ID { get; set; }
        public int SoThuTu { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public GioiTinh GioiTinh { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string ID_Khoa { get; set; }
        public Status IsActive { get; set; }
        public Khoa Khoa { get; set; }
        [JsonIgnore]
        public List<LopBienChe> LopBienChes { get; set; }
        [JsonIgnore]
        public List<LopHocPhan> LopHocPhans { get; set; }
        [JsonIgnore]
        public List<ChuyenMon> ChuyenMons { get; set; }
    }
}
