using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using QuanLySinhVien.Data.Entities;

namespace QuanLySinhVien.ViewModel.Catalog.HocKyNamHocs
{
    public class HocKyNamHocViewModel
    {
        public int HocKy { get; set; }
        public int NamHoc { get; set; }
        [DataType(DataType.Date)]
        public DateTime NgayBatDau { get; set; }
        [DataType(DataType.Date)]
        public DateTime NgayKetThuc { get; set; }
        public List<ChiTiet_ChuongTrinhDaoTao_MonHoc> ChiTiet_ChuongTrinhDaoTao_MonHocs { get; set; }
        public List<LopHocPhan> LopHocPhans { get; set; }
    }
}
