using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLySinhVien.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Data.Configurations
{
    public class MonHoc_Configuaration : IEntityTypeConfiguration<MonHoc>
    {
        public void Configure(EntityTypeBuilder<MonHoc> builder)
        {
            builder.ToTable("MonHocs");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID).HasMaxLength(10);

            builder.Property(x => x.SoThuTu).IsRequired();

            builder.Property(x=> x.TenMonHoc).IsRequired();

            builder.Property(x => x.SoTinChi).IsRequired();
            
            builder.Property(x => x.SoTiet).IsRequired();

            builder.HasOne(x => x.Khoa).WithMany(x => x.MonHocs).HasForeignKey(x => x.ID_Khoa);

        }
    }
}
