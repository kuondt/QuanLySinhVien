using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace QuanLySinhVien.Data.Entities
{
    [JsonObject(IsReference = true)]
    public class ChuongTrinhDaoTao
    {
        public string ID { get; set; }
        public string TenChuongTrinh { get; set; }
        public int SoThuTu { get; set; }
        public int Nam { get; set; }
        public string Id_Khoa { get; set; }
        public Khoa Khoa { get; set; }
        [JsonIgnore]
        public List<ChiTiet_ChuongTrinhDaoTao_MonHoc> ChiTiet_ChuongTrinhDaoTao_MonHocs { get; set; }
        [JsonIgnore]
        public List<SinhVien> SinhViens { get; set; }
    }
}
