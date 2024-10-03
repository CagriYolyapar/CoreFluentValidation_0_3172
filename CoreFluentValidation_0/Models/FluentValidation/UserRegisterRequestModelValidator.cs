using CoreFluentValidation_0.Models.ViewModels.AppUsers.RequestModels;
using FluentValidation;

namespace CoreFluentValidation_0.Models.FluentValidation
{
    public class UserRegisterRequestModelValidator : AbstractValidator<UserRegisterRequestModel>
    {

        public UserRegisterRequestModelValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName alanı gereklidir");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Sifre gereklidir").MinimumLength(3).WithMessage("Minimum 3 karakter gereklidir");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Sifreler uyusmuyor");
            RuleFor(x => x.Email).EmailAddress().NotEmpty().WithMessage("Email giriniz").When(x => x.UserName == null);
        }
    }
}
