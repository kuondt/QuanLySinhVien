﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuanLySinhVien.Data.EF;

namespace QuanLySinhVien.Data.Migrations
{
    [DbContext(typeof(QLSV_DBContext))]
    [Migration("20200816111139_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("AppRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("AppUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("AppUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("AppUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("AppUserTokens");
                });

            modelBuilder.Entity("QuanLySinhVien.Data.Entities.AppConfig", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Key");

                    b.ToTable("AppConfig");
                });

            modelBuilder.Entity("QuanLySinhVien.Data.Entities.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppRoles");
                });

            modelBuilder.Entity("QuanLySinhVien.Data.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Ho")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("QuanLySinhVien.Data.Entities.ChiTiet_ChuongTrinhDaoTao_MonHoc", b =>
                {
                    b.Property<string>("ID_ChuongTrinhDaoTao")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ID_MonHoc")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("HK_HocKy")
                        .HasColumnType("int");

                    b.Property<int>("HK_NamHoc")
                        .HasColumnType("int");

                    b.HasKey("ID_ChuongTrinhDaoTao", "ID_MonHoc", "HK_HocKy", "HK_NamHoc");

                    b.HasIndex("ID_MonHoc");

                    b.HasIndex("HK_HocKy", "HK_NamHoc");

                    b.ToTable("ChiTiet_ChuongTrinhDaoTao_MonHoc");
                });

            modelBuilder.Entity("QuanLySinhVien.Data.Entities.ChuongTrinhDaoTao", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Id_Khoa")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenChuongTrinh")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("ID");

                    b.HasIndex("Id_Khoa");

                    b.ToTable("ChuongTrinhDaoTao");
                });

            modelBuilder.Entity("QuanLySinhVien.Data.Entities.DanhSach_SinhVien_LopHocPhan", b =>
                {
                    b.Property<string>("ID_SinhVien")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ID_LopHocPhan")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("Diem")
                        .HasColumnType("real");

                    b.Property<int>("LanThi")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.HasKey("ID_SinhVien", "ID_LopHocPhan");

                    b.HasIndex("ID_LopHocPhan");

                    b.ToTable("DanhSach_SinhVien_LopHocPhan");
                });

            modelBuilder.Entity("QuanLySinhVien.Data.Entities.GiangVien", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("GioiTinh")
                        .HasColumnType("bit");

                    b.Property<string>("Ho")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("HoTen")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("ID_Khoa")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.HasIndex("ID_Khoa");

                    b.ToTable("GiangVien");
                });

            modelBuilder.Entity("QuanLySinhVien.Data.Entities.HocKy_NamHoc", b =>
                {
                    b.Property<int>("HocKy")
                        .HasColumnType("int");

                    b.Property<int>("NamHoc")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayKetThuc")
                        .HasColumnType("datetime2");

                    b.HasKey("HocKy", "NamHoc");

                    b.ToTable("HocKy_NamHoc");
                });

            modelBuilder.Entity("QuanLySinhVien.Data.Entities.Khoa", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenKhoa")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.ToTable("Khoa");
                });

            modelBuilder.Entity("QuanLySinhVien.Data.Entities.LopBienChe", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ID_GiangVien")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ID_Khoa")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("NamBatDau")
                        .HasColumnType("int");

                    b.Property<int>("NamKetThuc")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ID_GiangVien");

                    b.HasIndex("ID_Khoa");

                    b.ToTable("LopBienChe");
                });

            modelBuilder.Entity("QuanLySinhVien.Data.Entities.LopHocPhan", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("HK_HocKy")
                        .HasColumnType("int");

                    b.Property<int>("HK_NamHoc")
                        .HasColumnType("int");

                    b.Property<string>("ID_MonHoc")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ID_Phong")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("SoTietHoc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ID_MonHoc");

                    b.HasIndex("ID_Phong");

                    b.HasIndex("HK_HocKy", "HK_NamHoc");

                    b.ToTable("LopHocPhan");
                });

            modelBuilder.Entity("QuanLySinhVien.Data.Entities.MonHoc", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Id_Khoa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KhoaID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SoTiet")
                        .HasColumnType("int");

                    b.Property<int>("SoTinChi")
                        .HasColumnType("int");

                    b.Property<string>("TenMonHoc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("KhoaID");

                    b.ToTable("MonHoc");
                });

            modelBuilder.Entity("QuanLySinhVien.Data.Entities.PhanCong", b =>
                {
                    b.Property<string>("ID_LopHocPhan")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ID_GiangVien")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID_LopHocPhan", "ID_GiangVien");

                    b.HasIndex("ID_GiangVien");

                    b.HasIndex("ID_LopHocPhan")
                        .IsUnique();

                    b.ToTable("PhanCong");
                });

            modelBuilder.Entity("QuanLySinhVien.Data.Entities.Phong", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SoThuTu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenCoSo")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.ToTable("Phong");
                });

            modelBuilder.Entity("QuanLySinhVien.Data.Entities.SinhVien", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("GioiTinh")
                        .HasColumnType("int");

                    b.Property<string>("Ho")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("HoTen")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("ID_LopBienChe")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("NgaySinh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.HasIndex("ID_LopBienChe");

                    b.ToTable("SinhVien");
                });

            modelBuilder.Entity("QuanLySinhVien.Data.Entities.ChiTiet_ChuongTrinhDaoTao_MonHoc", b =>
                {
                    b.HasOne("QuanLySinhVien.Data.Entities.ChuongTrinhDaoTao", "ChuongTrinhDaoTao")
                        .WithMany("ChiTiet_ChuongTrinhDaoTao_MonHocs")
                        .HasForeignKey("ID_ChuongTrinhDaoTao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLySinhVien.Data.Entities.MonHoc", "MonHoc")
                        .WithMany("ChiTiet_ChuongTrinhDaoTao_MonHocs")
                        .HasForeignKey("ID_MonHoc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLySinhVien.Data.Entities.HocKy_NamHoc", "HocKy_NamHoc")
                        .WithMany("ChiTiet_ChuongTrinhDaoTao_MonHocs")
                        .HasForeignKey("HK_HocKy", "HK_NamHoc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuanLySinhVien.Data.Entities.ChuongTrinhDaoTao", b =>
                {
                    b.HasOne("QuanLySinhVien.Data.Entities.Khoa", "Khoa")
                        .WithMany("ChuongTrinhDaoTaos")
                        .HasForeignKey("Id_Khoa");
                });

            modelBuilder.Entity("QuanLySinhVien.Data.Entities.DanhSach_SinhVien_LopHocPhan", b =>
                {
                    b.HasOne("QuanLySinhVien.Data.Entities.LopHocPhan", "LopHocPhan")
                        .WithMany("ChiTiet_SinhVien_LopHocPhans")
                        .HasForeignKey("ID_LopHocPhan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLySinhVien.Data.Entities.SinhVien", "SinhVien")
                        .WithMany("ChiTiet_SinhVien_LopHocPhans")
                        .HasForeignKey("ID_SinhVien")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuanLySinhVien.Data.Entities.GiangVien", b =>
                {
                    b.HasOne("QuanLySinhVien.Data.Entities.Khoa", "Khoa")
                        .WithMany("GiangViens")
                        .HasForeignKey("ID_Khoa");
                });

            modelBuilder.Entity("QuanLySinhVien.Data.Entities.LopBienChe", b =>
                {
                    b.HasOne("QuanLySinhVien.Data.Entities.GiangVien", "GiangVien")
                        .WithMany("LopBienChes")
                        .HasForeignKey("ID_GiangVien");

                    b.HasOne("QuanLySinhVien.Data.Entities.Khoa", "Khoa")
                        .WithMany("LopBienChes")
                        .HasForeignKey("ID_Khoa");
                });

            modelBuilder.Entity("QuanLySinhVien.Data.Entities.LopHocPhan", b =>
                {
                    b.HasOne("QuanLySinhVien.Data.Entities.MonHoc", "MonHoc")
                        .WithMany("LopHocPhans")
                        .HasForeignKey("ID_MonHoc");

                    b.HasOne("QuanLySinhVien.Data.Entities.Phong", "Phong")
                        .WithMany("LopHocPhans")
                        .HasForeignKey("ID_Phong");

                    b.HasOne("QuanLySinhVien.Data.Entities.HocKy_NamHoc", "HocKy_NamHoc")
                        .WithMany("LopHocPhans")
                        .HasForeignKey("HK_HocKy", "HK_NamHoc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuanLySinhVien.Data.Entities.MonHoc", b =>
                {
                    b.HasOne("QuanLySinhVien.Data.Entities.Khoa", "Khoa")
                        .WithMany("MonHocs")
                        .HasForeignKey("KhoaID");
                });

            modelBuilder.Entity("QuanLySinhVien.Data.Entities.PhanCong", b =>
                {
                    b.HasOne("QuanLySinhVien.Data.Entities.GiangVien", "GiangVien")
                        .WithMany("PhanCongs")
                        .HasForeignKey("ID_GiangVien")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuanLySinhVien.Data.Entities.LopHocPhan", "LopHocPhan")
                        .WithOne("PhanCong")
                        .HasForeignKey("QuanLySinhVien.Data.Entities.PhanCong", "ID_LopHocPhan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuanLySinhVien.Data.Entities.SinhVien", b =>
                {
                    b.HasOne("QuanLySinhVien.Data.Entities.LopBienChe", "LopBienChe")
                        .WithMany("SinhViens")
                        .HasForeignKey("ID_LopBienChe");
                });
#pragma warning restore 612, 618
        }
    }
}