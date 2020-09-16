using System;
using System.Collections.Generic;
using System.Text;
using QuanLySinhVien.Data.Enums;

namespace QuanLySinhVien.Service.Catalog.LopHocPhans
{
    public interface IScheduleService
    {
        BuoiHoc RandomBuoiHoc(int randomBuoiHoc);

        NgayHoc RandomNgayHoc(int randomNgayHoc);
    }
}
