using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace QuanLySinhVien.Data.Entities
{
    [JsonObject(IsReference = true)]
    public class ChuyenMon
    {
        public string ID_GiangVien { get; set; }
        public string ID_MonHoc { get; set; }
    }
}
