using System;
using System.Collections.Generic;
using System.Text;
using QuanLySinhVien.Data.Enums;

namespace QuanLySinhVien.Service.Catalog.LopHocPhans
{
    public class RandomBuoiHocNgayHoc
    {
        public BuoiHoc RandomBuoiHoc(int randomBuoiHoc)
        {
            BuoiHoc buoiHoc = BuoiHoc.Sang;
            switch (randomBuoiHoc)
            {
                case 1:
                    buoiHoc = BuoiHoc.Sang;
                    break;
                case 2:
                    buoiHoc = BuoiHoc.Chieu;
                    break;
                case 3:
                    buoiHoc = BuoiHoc.Toi;
                    break;
            }
            return buoiHoc;
        }
    }
}
