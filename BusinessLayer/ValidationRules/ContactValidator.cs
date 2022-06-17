using EntityLayer.Concreate;
using FluentValidation;
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
            RuleFor(x => x.ContactMail).NotEmpty().WithMessage("Mail kısmını bos gecemezsiniz");
            RuleFor(x => x.ContactUsername).NotEmpty().WithMessage("Kullanıcı adı kısmını bos gecemezsiniz");
            RuleFor(x => x.ContactSubject).NotEmpty().WithMessage("Konu kismini bos gecemezsiniz");
            RuleFor(x => x.ContactUsername).MinimumLength(3).WithMessage("En az 3 karakter giriniz");  
        }
    }
}
