using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("İsim alanı boş geçilemez.");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Kategori isim alanı minimum 3 karakter olmalıdır.");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Kategori isim alanı maksimum 20 karakter olmalıdır.");

            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklama alanı boş geçilemez.");
        }
    }
}
