using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Data.Entities
{
    public class ChiTiet_ChuongTrinhDaoTao_MonHoc
    {
        public string ID { get; set; }
        public string ID_ChuongTrinhDaoTao { get; set; }
        public int HK_HocKy { get; set; }
        public int HK_NamHoc { get; set; }
        public string ID_MonHoc { get; set; }
        public ChuongTrinhDaoTao ChuongTrinhDaoTao { get; set; }
        public HocKy_NamHoc HocKy_NamHoc { get; set; }
        public MonHoc MonHoc { get; set; }
    }
}
