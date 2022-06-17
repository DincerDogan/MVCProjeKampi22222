using EntityLayer.Concreate;
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
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adini Bos Gecemezsiniz");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("YAzar Soyadini bos gecemezsiniz");
            RuleFor(x => x.WriterSurname).MinimumLength(3).WithMessage("En az 3 karakter giriniz");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("En fazla 50 karakter giriniz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkinda kismini bos gecemezsiniz");
            RuleFor(x => x.WriterAbout).Must(x => x.Contains('a')).WithMessage("hakkında kismina a harfi eklemelisiniz");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Unvanı bos birakamazsınız");



        }
    }
}
