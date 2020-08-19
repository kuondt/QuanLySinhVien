using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLySinhVien.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Data.Configurations
{
    public class Khoa_Configuaration : IEntityTypeConfiguration<Khoa>
    {
        public void Configure(EntityTypeBuilder<Khoa> builder)
        {
            builder.ToTable("Khoas");
            //Set primary Key
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID).HasMaxLength(10);

            builder.Property(x => x.TenKhoa).IsRequired().HasMaxLength(100);
        }
    }
}
