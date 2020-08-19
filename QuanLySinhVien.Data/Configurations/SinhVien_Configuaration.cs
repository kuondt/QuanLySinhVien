using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Data.Configurations
{
    public class SinhVien_Configuaration : IEntityTypeConfiguration<SinhVien>
    {
        public void Configure(EntityTypeBuilder<SinhVien> builder)
        {
            builder.ToTable("SinhViens");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.SoThuTu).ValueGeneratedOnAdd();

            builder.Property(x => x.Nam);

            builder.Property(x => x.Ho).HasMaxLength(50);

            builder.Property(x => x.Ten).HasMaxLength(50);

            builder.Property(x => x.HoTen).HasMaxLength(100);

            builder.Property(x => x.NgaySinh);

            builder.Property(x => x.GioiTinh);

            builder.Property(x => x.SoDienThoai);

            builder.Property(x => x.Email).HasMaxLength(100);

            builder.Property(x => x.DiaChi).HasMaxLength(500);

            builder.Property(x => x.IsActive).HasDefaultValue(Status.Active);

            builder.HasOne(x => x.LopBienChe).WithMany(x => x.SinhViens).HasForeignKey(x => x.ID_LopBienChe);

        }
    }
}
