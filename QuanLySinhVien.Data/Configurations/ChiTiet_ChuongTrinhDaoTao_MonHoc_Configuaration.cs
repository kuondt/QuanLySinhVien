using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLySinhVien.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Data.Configurations
{
    public class ChiTiet_ChuongTrinhDaoTao_MonHoc_Configuaration : IEntityTypeConfiguration<ChiTiet_ChuongTrinhDaoTao_MonHoc>
    {
        public void Configure(EntityTypeBuilder<ChiTiet_ChuongTrinhDaoTao_MonHoc> builder)
        {
            builder.ToTable("ChiTiet_ChuongTrinhDaoTao_MonHocs");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID).HasMaxLength(10);

            builder.HasOne(x => x.ChuongTrinhDaoTao).WithMany(x => x.ChiTiet_ChuongTrinhDaoTao_MonHocs).HasForeignKey(x => x.ID_ChuongTrinhDaoTao);

            builder.HasOne(x => x.MonHoc).WithMany(x => x.ChiTiet_ChuongTrinhDaoTao_MonHocs).HasForeignKey(x => x.ID_MonHoc);

            builder.HasOne(x => x.HocKy_NamHoc).WithMany(x => x.ChiTiet_ChuongTrinhDaoTao_MonHocs).HasForeignKey(x => new { x.HK_HocKy, x.HK_NamHoc});

    
        }
    }
}
