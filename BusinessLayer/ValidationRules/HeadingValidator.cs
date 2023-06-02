using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class HeadingValidator : AbstractValidator<Heading>
    {
        public HeadingValidator()
        {
            RuleFor(x => x.HeadingName).NotEmpty().WithMessage("İsim alanı boş geçilemez.").MaximumLength(50).WithMessage("Başlık isim alanı maksimum 50 karakter olmalıdır.");
            RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Kategori alanı boş geçilemez.");
            RuleFor(x => x.WriterID).NotEmpty().WithMessage("Yazar alanı boş geçilemez.");
        }
    }
}
