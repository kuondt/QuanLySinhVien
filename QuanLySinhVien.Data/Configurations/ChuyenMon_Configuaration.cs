using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLySinhVien.Data.Entities;

namespace QuanLySinhVien.Data.Configurations
{
    public class ChuyenMon_Configuaration : IEntityTypeConfiguration<ChuyenMon>
    {
        public void Configure(EntityTypeBuilder<ChuyenMon> builder)
        {
            builder.ToTable("ChuyenMons");

            builder.HasKey(x => new { x.ID_GiangVien, x.ID_MonHoc });

            builder.HasOne(x => x.GiangVien).WithMany(x => x.ChuyenMons).HasForeignKey(x => x.ID_GiangVien);

            builder.HasOne(x => x.MonHoc).WithMany(x => x.ChuyenMons).HasForeignKey(x => x.ID_MonHoc);
        }
    }
}
