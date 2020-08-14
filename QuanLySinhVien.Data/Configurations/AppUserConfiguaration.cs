using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLySinhVien.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Data.Configurations
{
    public class AppUserConfiguaration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUsers");

            builder.Property(x => x.Ho).IsRequired().HasMaxLength(50);

            builder.Property(x => x.Ten).IsRequired().HasMaxLength(50);

            builder.Property(x => x.HoTen).IsRequired().HasMaxLength(100);

            builder.Property(x => x.NgaySinh).IsRequired();
        }
    }
}
