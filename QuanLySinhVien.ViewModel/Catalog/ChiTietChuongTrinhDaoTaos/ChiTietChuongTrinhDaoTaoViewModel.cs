using System;
using System.Collections.Generic;
using System.Text;
using QuanLySinhVien.Data.Entities;

namespace QuanLySinhVien.ViewModel.Catalog.ChiTietChuongTrinhDaoTaos
{
    public class ChiTietChuongTrinhDaoTaoViewModel
    {
        public string ID_ChuongTrinhDaoTao { get; set; }
        public int HK_HocKy { get; set; }
        public int HK_NamHoc { get; set; }
        public string ID_MonHoc { get; set; }
        public ChuongTrinhDaoTao ChuongTrinhDaoTao { get; set; }
        public HocKy_NamHoc HocKy_NamHoc { get; set; }
        public MonHoc MonHoc { get; set; }
    }
}
