using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("İsim alanı boş geçilemez.").MinimumLength(2).WithMessage("İsim alanı minimum 2 karakter olmalıdır.").MaximumLength(50).WithMessage("İsim alanı maksimum 50 karakter olmalıdır.");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Soyisim alanı boş geçilemez.").MinimumLength(2).WithMessage("Soyisim alanı minimum 2 karakter olmalıdır.").MaximumLength(50).WithMessage("Soyisim alanı maksimum 50 karakter olmalıdır.");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Unvan alanı boş geçilemez.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda alanı boş geçilemez.");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("E-Posta alanı boş geçilemez.");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre alanı boş geçilemez.");
            RuleFor(x => x.WriterImage).NotEmpty().WithMessage("Görsel alanı boş geçilemez.");
        }
    }
}
