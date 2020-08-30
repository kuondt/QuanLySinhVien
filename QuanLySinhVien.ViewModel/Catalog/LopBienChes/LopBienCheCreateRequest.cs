using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.ViewModel.Catalog.LopBienChes
{
    public class LopBienCheCreateRequest
    {
        public string ID { get; set; }
        public int SoThuTu { get; set; }
        public int NamBatDau { get; set; }
        public int NamKetThuc { get; set; }
        public string ID_Khoa { get; set; }
        public string ID_GiangVien { get; set; }
    }
}
