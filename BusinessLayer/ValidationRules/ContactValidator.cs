using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Validators;
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
            RuleFor(contact => contact.Message).NotEmpty().WithMessage("Mesaj Alanı Boş Bırakılamaz");
            RuleFor(contact => contact.Subject).NotEmpty().WithMessage("Konu Alanı Boş Bırakılamaz").MinimumLength(3).WithMessage("Konu En Az 3 Karakter Olmalıdır.").MaximumLength(50).WithMessage("Konu En Fazla 50 Karakter Olmalıdır.");
            RuleFor(contact => contact.UserName).NotEmpty().WithMessage("Kullanıcı Adı Alanı Boş Bırakılamaz").MinimumLength(3).WithMessage("Kullanıcı Adı En Az 3 Karakter Olmalıdır.");
            RuleFor(contact => contact.UserMail).NotEmpty().EmailAddress().WithMessage("Mail Adresi Zorunldur");
        }
    }
}
