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
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("E-Posta alanı boş geçilemez.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı alanı boş geçilemez.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu alanı boş geçilemez.").MinimumLength(3).WithMessage("Konu alanı minimum 3 karakter olmalıdır.").MaximumLength(50).WithMessage("Konu alanı maksimum 50 karakter olmalıdır.");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj alanı boş geçilemez.");
        }
    }
}
