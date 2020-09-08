using Microsoft.EntityFrameworkCore;
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
            builder.ToTable("DanhSach_SinhVien_LopHocPhans");

            builder.HasKey(x => new { x.ID_LopHocPhan, x.ID_SinhVien });

            builder.Property(x => x.LanThi);

            builder.Property(x => x.Diem);

            builder.HasCheckConstraint("CK_Diem_Duoi_10", "Diem <= 10");

            builder.HasOne(x => x.SinhVien).WithMany(x => x.ChiTiet_SinhVien_LopHocPhans).HasForeignKey(x => x.ID_SinhVien);

            builder.HasOne(x => x.LopHocPhan).WithMany(x => x.ChiTiet_SinhVien_LopHocPhans).HasForeignKey(x => x.ID_LopHocPhan);
        }
    }
}
