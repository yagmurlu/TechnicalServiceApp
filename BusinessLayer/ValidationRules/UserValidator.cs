using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {

            RuleFor(x => x.UserName).NotEmpty().WithMessage("İsim Boş Geçilemez!");
            RuleFor(x => x.UserSurname).NotEmpty().WithMessage("Soyisim Boş Geçilemez!");
            RuleFor(x => x.UserName).MaximumLength(50).WithMessage("Maximum 50 karakter!");
            RuleFor(x => x.UserSurname).MaximumLength(50).WithMessage("Maximum 50 karakter!");
            RuleFor(x => x.UserPassword).NotEmpty().WithMessage("Boş Geçilemez!");
            RuleFor(x => x.UserNewPassword).NotEmpty().WithMessage("Boş Geçilemez!");
            RuleFor(x => x.UserAbout).NotEmpty().WithMessage("Boş Geçilemez!");
            RuleFor(x => x.UserAbout).MaximumLength(100).WithMessage("Maximum 100 Karakter!");
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Boş Geçilemez!");
        }
    }
}
