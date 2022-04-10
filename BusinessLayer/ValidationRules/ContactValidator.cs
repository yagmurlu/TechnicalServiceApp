using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.RecevierMail).NotEmpty().WithMessage("Alıcı Adresi Boş Geçilemez!");
            RuleFor(x => x.Heading).NotEmpty().WithMessage("Konu Boş Geçilemez!");
            RuleFor(x => x.Heading).MinimumLength(5).WithMessage("En az 5 karakter giriniz!");
            RuleFor(x => x.Contents).NotEmpty().WithMessage("İçerik Boş Geçilemez!");
            RuleFor(x => x.Heading).MaximumLength(50).WithMessage("En fazla 50 karakter girebilirsiniz!");
        }
    }
}
