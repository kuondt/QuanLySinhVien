using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Data.Entities
{
    public class HocKy_NamHoc
    {
        public int HocKy { get; set; }
        public int NamHoc { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public List<ChiTiet_ChuongTrinhDaoTao_MonHoc> ChiTiet_ChuongTrinhDaoTao_MonHocs { get; set; }
        public List<LopHocPhan> LopHocPhans { get; set; }
    }
}
