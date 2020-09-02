using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace QuanLySinhVien.Data.Entities
{
    [JsonObject(IsReference = true)]
    public class LopBienChe
    {
        public string ID { get; set; }
        public int SoThuTu { get; set; }
        public int NamBatDau { get; set; }
        public int NamKetThuc { get; set; }
        public string ID_Khoa { get; set; }
        public string ID_GiangVien { get; set; }
        public Khoa Khoa { get; set; }
        public GiangVien GiangVien { get; set; }
        [JsonIgnore]
        public List<SinhVien> SinhViens { get; set; }
    }
}
