using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLySinhVien.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Data.Configurations
{
    public class PhanCong_Configuaration : IEntityTypeConfiguration<PhanCong>
    {
        public void Configure(EntityTypeBuilder<PhanCong> builder)
        {
            builder.ToTable("PhanCongs");

            builder.HasKey(x => new { x.ID_LopHocPhan, x.ID_GiangVien });

            builder.HasOne(x => x.GiangVien).WithMany(x => x.PhanCongs).HasForeignKey(x => x.ID_GiangVien);

            builder.HasOne(x => x.LopHocPhan).WithOne(x => x.PhanCong).HasForeignKey<PhanCong>(x => x.ID_LopHocPhan);
        }
    }
}
