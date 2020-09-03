using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuanLySinhVien.ViewModel.Catalog.HocKyNamHocs
{
    public class HocKyNamHocCreateRequest
    {
        public int HocKy { get; set; }
        public int NamHoc { get; set; }
        [DataType(DataType.Date)]
        public DateTime NgayBatDau { get; set; }
        [DataType(DataType.Date)]
        public DateTime NgayKetThuc { get; set; }
    }
}
