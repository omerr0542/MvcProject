using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {

        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı Maili Boş Geçilemez.").EmailAddress().WithMessage("Mail Bilgisi Hatalı");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Boş Geçilemez.")
                                                     .MinimumLength(3).WithMessage("Konu En Az 10 Karakter Olmalıdır.")
                                                     .MaximumLength(500).WithMessage("Konu En Fazla 500 Karakter Olmalıdır.");

            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj Boş Geçilemez.")
                                                     .MinimumLength(3).WithMessage("İçerik En Az 10 Karakter Olmalıdır.")
                                                     .MaximumLength(500).WithMessage("İçerik En Fazla 500 Karakter Olmalıdır.");


        }
    }
}
