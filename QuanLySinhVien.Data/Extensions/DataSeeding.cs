using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Data.Extensions
{
    public static class DataSeeding
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
              new AppConfig() { Key = "HomeTitle", Value = "This is home" },
              new AppConfig() { Key = "HomeKeyword", Value = "This is keyword" },
              new AppConfig() { Key = "HomeDescription", Value = "This is description" }
              );

            var roleId = new Guid("7E2DE1EE-B97B-4698-ABE4-C22A0332B2C9");
            var roleId2 = new Guid("DDCFD40F-0C20-4BBD-AFBF-5936032DDDE5");
            var adminId = new Guid("8DD4E4E7-CBB1-4DB8-8CD8-3024401AFC74");
            modelBuilder.Entity<AppRole>().HasData(
                new AppRole
                {
                    Id = roleId,
                    Name = "admin",
                    NormalizedName = "admin",
                    Description = "Administrator role"
                },
                new AppRole
                {
                    Id = roleId2,
                    Name = "nhanvien",
                    NormalizedName = "nhanvien",
                    Description = "Nhân viên"
                }
            );

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "cuong.263@gmail.com",
                NormalizedEmail = "cuong.263@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin@123"),
                SecurityStamp = string.Empty,
                Ho = "Dao",
                Ten = "Cuong",
                HoTen = "Dao Cuong",
                NgaySinh = new DateTime(1998, 03, 26)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>
                {
                    RoleId = roleId,
                    UserId = adminId
                });

            modelBuilder.Entity<Khoa>().HasData(
                new Khoa() { ID = "KTCN", TenKhoa = "Kỹ thuật công nghệ" });

            modelBuilder.Entity<ChuongTrinhDaoTao>().HasData(
                new ChuongTrinhDaoTao() { ID = "HTTT2016", TenChuongTrinh = "HTTT", Nam = 2016, Id_Khoa = "KTCN" });

            modelBuilder.Entity<MonHoc>().HasData(
                new MonHoc() { ID = "INT001", SoThuTu = 1, TenMonHoc = "Kỹ thuật lập trình", SoTiet = 30, SoTinChi = 2, ID_Khoa = "KTCN" },
                new MonHoc() { ID = "INT002", SoThuTu = 2, TenMonHoc = "Cấu trúc dữ liệu và giải thuật", SoTiet = 30, SoTinChi = 2, ID_Khoa = "KTCN" },
                new MonHoc() { ID = "INT003", TenMonHoc = "Cơ sở dữ liệu", SoTiet = 45, SoTinChi = 3, ID_Khoa = "KTCN", SoThuTu = 3 },
                new MonHoc() { ID = "INT004", TenMonHoc = "Hệ điều hành	", SoTiet = 45, SoTinChi = 3, ID_Khoa = "KTCN", SoThuTu = 4 },
                new MonHoc() { ID = "INT005", TenMonHoc = "Vật lý đại cương", SoTiet = 45, SoTinChi = 3, ID_Khoa = "KTCN", SoThuTu = 5 },
                new MonHoc() { ID = "INT006", TenMonHoc = "Toán cao cấp", SoTiet = 30, SoTinChi = 2, ID_Khoa = "KTCN", SoThuTu = 6 }
                );

            modelBuilder.Entity<GiangVien>().HasData(
                new GiangVien()
                {
                    ID = "GV001",
                    SoThuTu = 1,
                    Ho = "Nguyễn Văn",
                    Ten = "A",
                    HoTen = "Nguyễn Văn A",
                    DiaChi = "624 Âu Cơ",
                    SoDienThoai = "0987654321",
                    Email = "nva@vhu.edu.vn",
                    GioiTinh = GioiTinh.Nam,
                    ID_Khoa = "KTCN",
                    IsActive = Status.Active,
                    NgaySinh = new DateTime(1975, 12, 01)
                },
                new GiangVien()
                {
                    ID = "GV002",
                    SoThuTu = 2,
                    Ho = "Phạm Văn",
                    Ten = "B",
                    HoTen = "Phạm Văn B",
                    DiaChi = "642 Âu Cơ",
                    SoDienThoai = "012332123",
                    Email = "pvb@vhu.edu.vn",
                    GioiTinh = GioiTinh.Nam,
                    ID_Khoa = "KTCN",
                    IsActive = Status.Active,
                    NgaySinh = new DateTime(1990, 01, 01)
                });

            modelBuilder.Entity<LopBienChe>().HasData(
                new LopBienChe() { ID = "161A0101", NamBatDau = 2016, NamKetThuc = 2020, ID_Khoa = "KTCN", ID_GiangVien = "GV001", SoThuTu = 1 }
                );

            modelBuilder.Entity<SinhVien>().HasData(
                new SinhVien()
                {
                    ID = "161A010001",
                    SoThuTu = 1,
                    Nam = 2016,
                    Ho = "Nguyễn Thị",
                    Ten = "C",
                    HoTen = "Nguyễn Thị C",
                    DiaChi = "TPHCM",
                    SoDienThoai = "0123456789",
                    Email = "ntc@gmail.com",
                    GioiTinh = GioiTinh.Nu,
                    IsActive = Status.Active,
                    NgaySinh = new DateTime(1998, 01, 01),
                    ID_LopBienChe = "161A0101"
                },
                new SinhVien()
                {
                    ID = "161A010002",
                    SoThuTu = 2,
                    Nam = 2016,
                    Ho = "Nguyễn Văn",
                    Ten = "D",
                    HoTen = "Nguyễn Văn D",
                    DiaChi = "Hóc Môn",
                    SoDienThoai = "0321456987",
                    Email = "nvd@gmail.com",
                    GioiTinh = GioiTinh.Nam,
                    IsActive = Status.Active,
                    NgaySinh = new DateTime(1998, 07, 15),
                    ID_LopBienChe = "161A0101"
                },
                new SinhVien()
                {
                    ID = "161A010003",
                    SoThuTu = 3,
                    Nam = 2016,
                    Ho = "Đào Tuấn",
                    Ten = "Cường",
                    HoTen = "Đào Tuấn Cường",
                    DiaChi = "5/9A Hóc Môn",
                    SoDienThoai = "0904590481",
                    Email = "cuong.263@gmail.com",
                    GioiTinh = GioiTinh.Nam,
                    IsActive = Status.Active,
                    NgaySinh = new DateTime(1998, 03, 26),
                    ID_LopBienChe = "161A0101",
                }
            );

            modelBuilder.Entity<HocKy_NamHoc>().HasData(
                new HocKy_NamHoc() { HocKy = 1, NamHoc = 2016, NgayBatDau = new DateTime(2016, 01, 01), NgayKetThuc = new DateTime(2016, 04, 01) },
                new HocKy_NamHoc() { HocKy = 2, NamHoc = 2016, NgayBatDau = new DateTime(2016, 05, 01), NgayKetThuc = new DateTime(2016, 08, 01) },
                new HocKy_NamHoc() { HocKy = 3, NamHoc = 2016, NgayBatDau = new DateTime(2016, 09, 01), NgayKetThuc = new DateTime(2016, 12, 01) }
                );

            modelBuilder.Entity<Phong>().HasData(
                new Phong()
                {
                    ID = "PH001",
                    SoThuTu = 1,
                    TenCoSo = "624 Âu Cơ"
                },
                new Phong()
                {
                    ID = "PH002",
                    SoThuTu = 2,
                    TenCoSo = "624 Âu Cơ"
                },
                new Phong()
                {
                    ID = "PH003",
                    SoThuTu = 3,
                    TenCoSo = "624 Âu Cơ"
                });

            modelBuilder.Entity<ChiTiet_ChuongTrinhDaoTao_MonHoc>().HasData(
                new ChiTiet_ChuongTrinhDaoTao_MonHoc()
                {
                    ID_ChuongTrinhDaoTao = "HTTT2016",
                    HK_HocKy = 1,
                    HK_NamHoc = 2016,
                    ID_MonHoc = "INT001"
                }, new ChiTiet_ChuongTrinhDaoTao_MonHoc()
                {
                    ID_ChuongTrinhDaoTao = "HTTT2016",
                    HK_HocKy = 1,
                    HK_NamHoc = 2016,
                    ID_MonHoc = "INT005"
                },
                new ChiTiet_ChuongTrinhDaoTao_MonHoc()
                {
                    ID_ChuongTrinhDaoTao = "HTTT2016",
                    HK_HocKy = 1,
                    HK_NamHoc = 2016,
                    ID_MonHoc = "INT006"
                });

            modelBuilder.Entity<LopHocPhan>().HasData(
                new LopHocPhan()
                {
                    ID = "161INT001",
                    SoThuTu = 1,
                    HK_HocKy = 1,
                    HK_NamHoc = 2016,
                    ID_MonHoc = "INT001",
                    ID_Phong = "PH001",
                    BuoiHoc = BuoiHoc.Sang,
                    NgayHoc = NgayHoc.Thu2,
                    IsActive = Status.Active
                },
                new LopHocPhan()
                {
                    ID = "161INT002",
                    SoThuTu = 2,
                    HK_HocKy = 1,
                    HK_NamHoc = 2016,
                    ID_MonHoc = "INT001",
                    ID_Phong = "PH002",
                    BuoiHoc = BuoiHoc.Chieu,
                    NgayHoc = NgayHoc.Thu2,
                    IsActive = Status.Active
                },
                new LopHocPhan()
                {
                    ID = "161INT003",
                    SoThuTu = 3,
                    HK_HocKy = 1,
                    HK_NamHoc = 2016,
                    ID_MonHoc = "INT005",
                    ID_Phong = "PH003",
                    BuoiHoc = BuoiHoc.Toi,
                    NgayHoc = NgayHoc.Thu3,
                    IsActive = Status.Active
                },
                new LopHocPhan()
                {
                    ID = "161INT004",
                    SoThuTu = 4,
                    HK_HocKy = 1,
                    HK_NamHoc = 2016,
                    ID_MonHoc = "INT006",
                    ID_Phong = "PH002",
                    BuoiHoc = BuoiHoc.Sang,
                    NgayHoc = NgayHoc.Thu4,
                    IsActive = Status.Active
                });

            modelBuilder.Entity<PhanCong>().HasData(new PhanCong()
            {
                ID_LopHocPhan = "161INT001",
                ID_GiangVien = "GV001"
            },
            new PhanCong()
            {
                ID_LopHocPhan = "161INT002",
                ID_GiangVien = "GV001"
            },
            new PhanCong()
            {
                ID_LopHocPhan = "161INT003",
                ID_GiangVien = "GV002"
            },
            new PhanCong()
            {
                ID_LopHocPhan = "161INT004",
                ID_GiangVien = "GV002"
            });

            modelBuilder.Entity<DanhSach_SinhVien_LopHocPhan>().HasData(new DanhSach_SinhVien_LopHocPhan()
            {
                ID_LopHocPhan = "161INT001",
                ID_SinhVien = "161A010001",
                LanThi = 1,
                Diem = 8.5f
            },
            new DanhSach_SinhVien_LopHocPhan()
            {
                ID_LopHocPhan = "161INT002",
                ID_SinhVien = "161A010001",
                LanThi = 1,
                Diem = 10f
            },
            new DanhSach_SinhVien_LopHocPhan()
            {
                ID_LopHocPhan = "161INT001",
                ID_SinhVien = "161A010002",
                LanThi = 1,
                Diem = 7.0f
            },
            new DanhSach_SinhVien_LopHocPhan()
            {
                ID_LopHocPhan = "161INT001",
                ID_SinhVien = "161A010003",
                LanThi = 1,
                Diem = 7.0f
            });
        }
    }
}
