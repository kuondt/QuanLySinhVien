using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLySinhVien.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Data.Configurations
{
    public class LopBienChe_Configuaration : IEntityTypeConfiguration<LopBienChe>
    {
        public void Configure(EntityTypeBuilder<LopBienChe> builder)
        {
            builder.ToTable("LopBienChes");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID).HasMaxLength(10);

            builder.Property(x => x.SoThuTu);

            builder.Property(x => x.NamBatDau);

            builder.Property(x => x.NamKetThuc);

            builder.HasOne(x => x.Khoa).WithMany(x => x.LopBienChes).HasForeignKey(x => x.ID_Khoa);

            builder.HasOne(x => x.GiangVien).WithMany(x => x.LopBienChes).HasForeignKey(x => x.ID_GiangVien);
        }
    }
}
