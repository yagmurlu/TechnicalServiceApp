using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AdminValidator:AbstractValidator <Admin>
    {
        public AdminValidator()
        {

            RuleFor(x => x.AdminName).NotEmpty().WithMessage("İsim Boş Geçilemez!");
            RuleFor(x => x.AdminSurname).NotEmpty().WithMessage("Soyisim Boş Geçilemez!");
            RuleFor(x => x.AdminName).MaximumLength(50).WithMessage("Maximum 50 karakter!");
            RuleFor(x => x.AdminSurname).MaximumLength(50).WithMessage("Maximum 50 karakter!");
            RuleFor(x => x.AdminPassword).NotEmpty().WithMessage("Boş Geçilemez!");
            RuleFor(x => x.AdminNewPassword).NotEmpty().WithMessage("Boş Geçilemez!");
            RuleFor(x => x.AdminMail).NotEmpty().WithMessage("Boş Geçilemez!");
           
        }
    }
}
