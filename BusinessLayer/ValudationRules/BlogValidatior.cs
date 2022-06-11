using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValudationRules
{
    public class BlogValidatior : AbstractValidator<Blog>
    {
        public BlogValidatior()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Блок загловка пустой");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Контент пустой");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Фото отсуствует");
            RuleFor(x => x.BlogTitle).MinimumLength(2).WithMessage("Lutfen en az 2 karakter girisi yapin");
            RuleFor(x => x.BlogTitle).MaximumLength(50).WithMessage("Lutfen en fazla 50 karakterlik veri girisi yapin");
        }
    }
}