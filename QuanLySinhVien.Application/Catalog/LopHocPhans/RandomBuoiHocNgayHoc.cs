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

        public NgayHoc RandomNgayHoc(int randomNgayHoc)
        {
            NgayHoc ngayHoc = NgayHoc.Thu2;
            switch (randomNgayHoc)
            {
                case 2:
                    ngayHoc = NgayHoc.Thu2;
                    break;
                case 3:
                    ngayHoc = NgayHoc.Thu3;
                    break;
                case 4:
                    ngayHoc = NgayHoc.Thu4;
                    break;
                case 5:
                    ngayHoc = NgayHoc.Thu5;
                    break;
                case 6:
                    ngayHoc = NgayHoc.Thu6;
                    break;
                case 7:
                    ngayHoc = NgayHoc.Thu7;
                    break;
                case 8:
                    ngayHoc = NgayHoc.ChuNhat;
                    break;
            }
            return ngayHoc;
        }
    }
}
