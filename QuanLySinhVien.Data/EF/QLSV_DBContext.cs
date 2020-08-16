using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.Data.Configurations;
using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Data.EF
{
    public class QLSV_DBContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public QLSV_DBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configuation using Fluent API
            modelBuilder.ApplyConfiguration(new AppConfigConfiguration());
            modelBuilder.ApplyConfiguration(new ChiTiet_ChuongTrinhDaoTao_MonHoc_Configuaration());
            modelBuilder.ApplyConfiguration(new DanhSach_SinhVien_LopHocPhan_Configuaration());
            modelBuilder.ApplyConfiguration(new ChuongTrinhDaoTao_Configuaration());
            modelBuilder.ApplyConfiguration(new GiangVien_Configuaration());
            modelBuilder.ApplyConfiguration(new HocKy_Configuaration());
            modelBuilder.ApplyConfiguration(new Khoa_Configuaration());
            modelBuilder.ApplyConfiguration(new LopBienChe_Configuaration());
            modelBuilder.ApplyConfiguration(new LopHocPhan_Configuaration());
            modelBuilder.ApplyConfiguration(new PhanCong_Configuaration());
            modelBuilder.ApplyConfiguration(new Phong_Configuaration());
            modelBuilder.ApplyConfiguration(new SinhVien_Configuaration());

            //Config Identity
            modelBuilder.ApplyConfiguration(new AppUserConfiguaration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguaration());
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);

            //Database seeding
            modelBuilder.Seed();
        }

        public DbSet<ChiTiet_ChuongTrinhDaoTao_MonHoc> ChiTiet_ChuongTrinhDaoTao_MonHoc { get; set; }

        public DbSet<DanhSach_SinhVien_LopHocPhan> DanhSach_SinhVien_LopHocPhan { get; set; }

        public DbSet<ChuongTrinhDaoTao> ChuongTrinhDaoTao { get; set; }

        public DbSet<GiangVien> GiangVien { get; set; }

        public DbSet<HocKy_NamHoc> HocKy_NamHoc { get; set; }

        public DbSet<Khoa> Khoa { get; set; }

        public DbSet<LopBienChe> LopBienChe { get; set; }

        public DbSet<LopHocPhan> LopHocPhan { get; set; }

        public DbSet<MonHoc> MonHoc { get; set; }

        public DbSet<PhanCong> PhanCong { get; set; }

        public DbSet<Phong> Phong { get; set; }

        public DbSet<SinhVien> SinhVien { get; set; }

    }
}
