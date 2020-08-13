using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Data.EF
{
    public class QLSV_DBContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public QLSV_DBContext(DbContextOptions options) : base(options)
        {
        }
    }
}
