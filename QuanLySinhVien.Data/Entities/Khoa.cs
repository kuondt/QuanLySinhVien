using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Data.Entities
{
    public class Khoa
    {
        public string ID { get; set; }
	    public string TenKhoa   {get; set;}
        public List<ChuongTrinhDaoTao> ChuongTrinhDaoTaos { get; set; }
        public List<LopBienChe> LopBienChes { get; set; }
        public List<MonHoc> MonHocs { get; set; }
        public List<GiangVien> GiangViens { get; set; }

    }
}
