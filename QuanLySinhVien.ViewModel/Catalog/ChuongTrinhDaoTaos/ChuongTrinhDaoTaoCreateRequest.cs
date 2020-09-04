using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.ViewModel.Catalog.ChuongTrinhDaoTaos
{
    public class ChuongTrinhDaoTaoCreateRequest
    {
        public string ID { get; set; }
        public string TenChuongTrinh { get; set; }
        public int SoThuTu { get; set; }
        public int Nam { get; set; }
        public string Id_Khoa { get; set; }
    }
}
