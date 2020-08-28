﻿using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.ViewModel.Catalog.GiangViens
{
    public class GiangVienUpdateRequest
    {
        public string ID { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public DateTime NgaySinh { get; set; }
        public GioiTinh GioiTinh { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string ID_Khoa { get; set; }
        public Status IsActive { get; set; }
    }
}
