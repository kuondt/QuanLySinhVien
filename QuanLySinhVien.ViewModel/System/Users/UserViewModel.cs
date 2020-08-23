using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuanLySinhVien.ViewModel.System.Users
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Họ")]
        public string Ho { get; set; }

        [Display(Name = "Tên")]
        public string Ten { get; set; }

        [Display(Name = "Họ Tên")]
        public string HoTen { get; set; }

        [Display(Name = "Tài khoản")]
        public string UserName { get; set; }

        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime NgaySinh { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Số điện thoại")]
        public string SoDienThoai { get; set; }

        public IList<string> Roles { get; set; }
    }
}
