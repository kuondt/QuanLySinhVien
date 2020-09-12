using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Data.Configurations
{
    public class LopHocPhan_Configuaration : IEntityTypeConfiguration<LopHocPhan>
    {
        public void Configure(EntityTypeBuilder<LopHocPhan> builder)
        {
            builder.ToTable("LopHocPhans");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID).HasMaxLength(12);

            builder.Property(x => x.SoThuTu);

            builder.Property(x => x.BuoiHoc);

            builder.Property(x => x.NgayHoc);

            builder.Property(x => x.IsActive).HasDefaultValue(Status.Active);

            builder.HasOne(x => x.MonHoc).WithMany(x => x.LopHocPhans).HasForeignKey(x => x.ID_MonHoc);

            builder.HasOne(x => x.Phong).WithMany(x => x.LopHocPhans).HasForeignKey(x => x.ID_Phong);

            builder.HasOne(x => x.HocKy_NamHoc).WithMany(x => x.LopHocPhans).HasForeignKey(x => new { x.HK_HocKy, x.HK_NamHoc });

            builder.HasOne(x => x.GiangVien).WithMany(x => x.LopHocPhans).HasForeignKey(x => x.ID_GiangVien);
        }
    }
}
