using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace QuanLySinhVien.Data.Entities
{
    public class ChuyenMon
    {
        public string ID_GiangVien { get; set; }
        public string ID_MonHoc { get; set; }
        public GiangVien GiangVien { get; set; }
        public MonHoc MonHoc { get; set; }
    }
}
