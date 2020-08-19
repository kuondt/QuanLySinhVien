using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLySinhVien.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Data.Configurations
{
    public class Phong_Configuaration : IEntityTypeConfiguration<Phong>
    {
        public void Configure(EntityTypeBuilder<Phong> builder)
        {
            builder.ToTable("Phongs");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID).HasMaxLength(10);

            builder.Property(x => x.TenCoSo).HasMaxLength(100);

            builder.Property(x => x.SoThuTu);
        }
    }
}
