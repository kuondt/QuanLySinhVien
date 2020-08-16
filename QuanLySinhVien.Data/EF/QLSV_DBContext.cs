using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.Data.Configurations;
using QuanLySinhVien.Data.Entities;
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

        }

        public DbSet<ChiTiet_ChuongTrinhDaoTao_MonHoc_Configuaration> Products { get; set; }

        public DbSet<DanhSach_SinhVien_LopHocPhan> Categories { get; set; }

        public DbSet<ChuongTrinhDaoTao> AppConfigs { get; set; }

        public DbSet<GiangVien> Carts { get; set; }

        public DbSet<HocKy_NamHoc> CategoryTranslations { get; set; }

        public DbSet<Khoa> ProductInCategories { get; set; }

        public DbSet<LopBienChe> Contacts { get; set; }

        public DbSet<LopHocPhan> Languages { get; set; }

        public DbSet<MonHoc> Orders { get; set; }

        public DbSet<PhanCong> OrderDetails { get; set; }

        public DbSet<Phong> ProductTranslations { get; set; }

        public DbSet<SinhVien> Promotions { get; set; }

    }
}
