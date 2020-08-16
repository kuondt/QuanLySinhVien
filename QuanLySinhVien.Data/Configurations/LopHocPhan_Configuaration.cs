using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLySinhVien.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Data.Configurations
{
    public class LopHocPhan_Configuaration : IEntityTypeConfiguration<LopHocPhan>
    {
        public void Configure(EntityTypeBuilder<LopHocPhan> builder)
        {
            builder.ToTable("LopHocPhan");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.SoTietHoc);

            builder.Property(x => x.IsActive).HasDefaultValue(true);

            builder.HasOne(x => x.MonHoc).WithMany(x => x.LopHocPhans).HasForeignKey(x => x.ID_MonHoc);

            builder.HasOne(x => x.Phong).WithMany(x => x.LopHocPhans).HasForeignKey(x => x.ID_Phong);

            builder.HasOne(x => x.HocKy_NamHoc).WithMany(x => x.LopHocPhans).HasForeignKey(x => x.HK_HocKy);

            builder.HasOne(x => x.HocKy_NamHoc).WithMany(x => x.LopHocPhans).HasForeignKey(x => x.HK_NamHoc);
        }
    }
}
