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
            RuleFor(X => X.WriterName).NotEmpty().WithMessage("İsim alanı boş geçilemez.").MinimumLength(2).WithMessage("İsim alanı minimum 2 karakter olmalıdır.").MaximumLength(50).WithMessage("İsim alanı maksimum 50 karakter olmalıdır.");
            RuleFor(X => X.WriterSurname).NotEmpty().WithMessage("Soyisim alanı boş geçilemez.").MinimumLength(2).WithMessage("Soyisim alanı minimum 2 karakter olmalıdır.").MaximumLength(50).WithMessage("Soyisim alanı maksimum 50 karakter olmalıdır.");
            RuleFor(X => X.WriterAbout).NotEmpty().WithMessage("Hakkımda alanı boş geçilemez.");
            RuleFor(X => X.WriterMail).NotEmpty().WithMessage("E-Posta alanı boş geçilemez.");
            RuleFor(X => X.WriterImage).NotEmpty().WithMessage("Görsel alanı boş geçilemez.");
        }
    }
}
