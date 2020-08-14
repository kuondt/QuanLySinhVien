using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Data.Entities
{
    public class ChuongTrinhDaoTao
    {
        public string ID { get; set; }
        public string TenChuongTrinh { get; set; }
        public string Nam { get; set; }
        public string Id_Khoa { get; set; }
        public Khoa Khoa { get; set; }
        public List<ChiTiet_ChuongTrinhDaoTao_MonHoc> ChiTiet_ChuongTrinhDaoTao_MonHocs { get; set; }
    }
}
