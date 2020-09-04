using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLySinhVien.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Data.Configurations
{
    class ChuongTrinhDaoTao_Configuaration : IEntityTypeConfiguration<ChuongTrinhDaoTao>
    {
        public void Configure(EntityTypeBuilder<ChuongTrinhDaoTao> builder)
        {
            builder.ToTable("ChuongTrinhDaoTaos");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID).HasMaxLength(10);

            builder.Property(x => x.TenChuongTrinh).HasMaxLength(200);

            builder.Property(x => x.Nam);

            builder.Property(x => x.SoThuTu);

            builder.HasOne(x => x.Khoa).WithMany(x => x.ChuongTrinhDaoTaos).HasForeignKey(x=> x.Id_Khoa);
        }
    }
}
