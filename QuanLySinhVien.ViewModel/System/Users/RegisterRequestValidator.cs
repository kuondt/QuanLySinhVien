using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.ViewModel.System.Users
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.Ho).NotEmpty().WithMessage("Yêu cầu nhập Họ")
                .MaximumLength(50).WithMessage("Họ không vượt quá 50 ký tự");

            RuleFor(x => x.Ten).NotEmpty().WithMessage("Yêu cầu nhập tên")
                .MaximumLength(50).WithMessage("Tên không vượt quá 50 ký tự");

            RuleFor(x => x.NgaySinh).GreaterThan(DateTime.Now.AddYears(-100)).WithMessage("Tuổi phải nhỏ hơn 100 năm");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Yêu cầu nhập Email")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage("Email không hợp lệ");

            RuleFor(x => x.SoDienThoai).NotEmpty().WithMessage("Yêu cầu nhập Số điện thoại");

            RuleFor(x => x.UserName).NotEmpty().WithMessage("Yêu cầu nhập Username");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Yêu cầu nhập Password")
                .MinimumLength(6).WithMessage("Password phải có ít nhất 6 ký tự");

            RuleFor(x => x).Custom((request, context) =>
            {
                if (request.Password != request.ConfirmPassword)
                {
                    context.AddFailure("Password nhập lại không khớp");
                }
            });
        }
    }
}
