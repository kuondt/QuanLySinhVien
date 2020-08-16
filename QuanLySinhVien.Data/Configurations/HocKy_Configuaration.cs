using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLySinhVien.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Data.Configurations
{
    public class HocKy_Configuaration : IEntityTypeConfiguration<HocKy_NamHoc>
    {
        public void Configure(EntityTypeBuilder<HocKy_NamHoc> builder)
        {
            builder.ToTable("HocKy_NamHocs");

            builder.HasKey(x => new { x.HocKy, x.NamHoc });

            builder.Property(x => x.NgayBatDau);

            builder.Property(x => x.NgayKetThuc);
        }
    }
}
