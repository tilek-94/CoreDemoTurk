using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValudationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Заполните имя категории");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Заполните кантент категории");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Имя категории больше 50 символа");
            RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("Имя категории менше 2 символа");
        }
    }
}
