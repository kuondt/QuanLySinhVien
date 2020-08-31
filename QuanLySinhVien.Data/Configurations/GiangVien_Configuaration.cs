using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Data.Configurations
{
    public class GiangVien_Configuaration : IEntityTypeConfiguration<GiangVien>
    {
        public void Configure(EntityTypeBuilder<GiangVien> builder)
        {
            builder.ToTable("GiangViens");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID).HasMaxLength(10);

            builder.Property(x => x.SoThuTu);

            builder.Property(x => x.Ho).IsRequired().HasMaxLength(50);

            builder.Property(x => x.Ten).IsRequired().HasMaxLength(50);

            builder.Property(x => x.HoTen).IsRequired().HasMaxLength(100);

            builder.Property(x => x.NgaySinh);

            builder.Property(x => x.GioiTinh);

            builder.Property(x => x.SoDienThoai);

            builder.Property(x => x.Email).HasMaxLength(100);

            builder.Property(x => x.DiaChi).HasMaxLength(500);

            builder.Property(x => x.IsActive).HasDefaultValue(Status.Active);

            builder.HasOne(x => x.Khoa).WithMany(x => x.GiangViens).HasForeignKey(x => x.ID_Khoa);
        }
    }
}
