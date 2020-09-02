using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace QuanLySinhVien.Data.Entities
{
    [JsonObject(IsReference = true)]
    public class Phong
    {
        public string ID { get; set; }
        public string TenCoSo { get; set; }
        public int SoThuTu { get; set; }
        [JsonIgnore]
        public List<LopHocPhan> LopHocPhans { get; set; }
    }
}
