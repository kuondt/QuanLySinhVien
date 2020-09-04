using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.ViewModel.Catalog.ChiTietChuongTrinhDaoTaos
{
    public class ChiTietChuongTrinhDaoTaoCreateRequest
    {
        public string ID_ChuongTrinhDaoTao { get; set; }
        public int HK_HocKy { get; set; }
        public int HK_NamHoc { get; set; }
        public string ID_MonHoc { get; set; }
    }
}
