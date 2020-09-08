using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.ViewModel.Catalog.ChiTietChuongTrinhDaoTaos
{
    public class ChiTietChuongTrinhDaoTaoUpdateRequest
    {
        public string ID_ChuongTrinhDaoTao { get; set; }
        public string ID_MonHoc { get; set; }
        public int HocKyDuKien { get; set; }
        public int Nam { get; set; }
    }
}
