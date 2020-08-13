using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Data.Entities
{
    public class LopBienChe
    {
        public string ID { get; set; }
        public int SiSo { get; set; }
        public int NamBatDau { get; set; }
        public int NamKetThuc { get; set; }
        public string ID_Khoa { get; set; }
        public string ID_GiangVien { get; set; }

    }
}
