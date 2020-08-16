﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLySinhVien.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Data.Configurations
{
    public class DanhSach_SinhVien_LopHocPhan_Configuaration : IEntityTypeConfiguration<DanhSach_SinhVien_LopHocPhan>
    {
        public void Configure(EntityTypeBuilder<DanhSach_SinhVien_LopHocPhan> builder)
        {
            builder.ToTable("DanhSach_SinhVien_LopHocPhans")

            builder.HasKey(x => new { x.ID_SinhVien, x.ID_LopHocPhan });

            builder.Property(x => x.LanThi).HasDefaultValue(1);

            builder.Property(x => x.Diem).IsRequired();

            builder.HasOne(x => x.SinhVien).WithMany(x => x.ChiTiet_SinhVien_LopHocPhans).HasForeignKey(x => x.ID_SinhVien);

            builder.HasOne(x => x.LopHocPhan).WithMany(x => x.ChiTiet_SinhVien_LopHocPhans).HasForeignKey(x => x.ID_LopHocPhan);
        }
    }
}
