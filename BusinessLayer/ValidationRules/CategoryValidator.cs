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
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adı boş geçilemez.")
                .Length(3, 20).WithMessage("Kategori adı 3 ile 20 karakter arasında olmalıdır.");
            RuleFor(x => x.CategoryDescription).MaximumLength(200).WithMessage("Kategori açıklaması 200 karakterden fazla olamaz.");
            RuleFor(x => x.CategoryStatus).NotNull().WithMessage("Kategori durumu boş geçilemez.");
        }
    }
}
