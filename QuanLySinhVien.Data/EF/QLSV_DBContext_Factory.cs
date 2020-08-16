using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QuanLySinhVien.Data.EF
{
    public class QLSV_DBContext_Factory : IDesignTimeDbContextFactory<QLSV_DBContext>
    {
        public QLSV_DBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("QuanLySinhVienDB");

            var optionsBuilder = new DbContextOptionsBuilder<QLSV_DBContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new QLSV_DBContext(optionsBuilder.Options);
        }
    }
}
