using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace QuanLySinhVien.Data.Entities
{
    [JsonObject(IsReference = true)]
    public class Khoa
    {
        public string ID { get; set; }
	    public string TenKhoa   {get; set;}
        [JsonIgnore]
        public List<ChuongTrinhDaoTao> ChuongTrinhDaoTaos { get; set; }
        [JsonIgnore]
        public List<LopBienChe> LopBienChes { get; set; }
        [JsonIgnore]
        public List<MonHoc> MonHocs { get; set; }
        [JsonIgnore]
        public List<GiangVien> GiangViens { get; set; }

    }
}
