using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu alanı boş geçilemez.").MinimumLength(3).WithMessage("Konu alanı minimum 3 karakter olmalıdır.").MaximumLength(50).WithMessage("Konu alanı maksimum 50 karakter olmalıdır.");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj içerik alanı boş geçilemez.");
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı mail alanı boş geçilemez.").EmailAddress().WithMessage("Lütfen E-Mail adresini doğru formatta giriniz.");
        }
    }
}
