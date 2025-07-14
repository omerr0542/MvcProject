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
            RuleFor(x => x.HeadingName)
                .NotEmpty().WithMessage("Başlık adı boş geçilemez.")
                .Length(2, 50).WithMessage("Başlık adı 2 ile 50 karakter arasında olmalıdır.");

            RuleFor(x => x.CategoryID)
                .NotEmpty().WithMessage("Kategori boş geçilemez.");

            RuleFor(x => x.WriterID)
                .NotEmpty().WithMessage("Yazar boş geçilemez.");
        }
    }
}
