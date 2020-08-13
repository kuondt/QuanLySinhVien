using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Data.EF
{
    public class QLSV_DBContext : DbContext
    {
        public QLSV_DBContext(DbContextOptions options) : base(options)
        {
        }
    }
}
