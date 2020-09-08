using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace QuanLySinhVien.Data.Entities
{
    [JsonObject(IsReference = true)]
    public class HocKy_NamHoc
    {
        public int HocKy { get; set; }
        public int NamHoc { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        [JsonIgnore]
        public List<LopHocPhan> LopHocPhans { get; set; }
    }
}
