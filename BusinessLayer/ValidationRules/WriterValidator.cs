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
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı boş geçilemez.")
                .Length(2, 20).WithMessage("Yazar adı 2 ile 20 karakter arasında olmalıdır.");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyadı boş geçilemez.")
                .Length(2, 50).WithMessage("Yazar soyadı 2 ile 50 karakter arasında olmalıdır.");

            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda Kısmı boş geçilemez.")
                .Must(x => x.Contains("a")).WithMessage("Hakkımda kısmında 'a' karakteri bulunmalıdır.");

            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Title Kısmı boş geçilemez.");
        }
    }
}
