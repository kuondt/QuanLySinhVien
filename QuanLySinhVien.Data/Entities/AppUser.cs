using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
    }
}
