using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValudationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adi soyadi kismi bos gesilemez");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail adresi bos gecilemez");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Sifre bos gesilemez");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lutfen en az 2 karakter girisi yapin");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lutfen en fazla 50 karakterlik veri girisi yapin");
        }
    }
}
