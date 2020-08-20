using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace QuanLySinhVien.ViewModel.System.Users
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Thiếu tên đăng nhập");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Thiếu mật khẩu");
        }
    }
}
