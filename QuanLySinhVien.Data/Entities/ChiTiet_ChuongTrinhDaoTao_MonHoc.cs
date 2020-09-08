using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Data.Entities
{
    public class ChiTiet_ChuongTrinhDaoTao_MonHoc
    {
        public string ID_ChuongTrinhDaoTao { get; set; }
        public string ID_MonHoc { get; set; }
        public int HocKyDuKien { get; set; }
        public int Nam { get; set; }
        public ChuongTrinhDaoTao ChuongTrinhDaoTao { get; set; }
        public MonHoc MonHoc { get; set; }
    }
}
