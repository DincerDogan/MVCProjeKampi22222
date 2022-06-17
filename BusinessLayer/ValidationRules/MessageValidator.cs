using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using EntityLayer.Concreate;

namespace BusinessLayer.ValidationRules
{
   public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı adresini bos gecemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu kısmını bos gecemezsiniz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("İcerik kismini bos gecemezsiniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("En az 3 karakter giriniz");
            RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("Lutfen gecerli bir mail adresi giriniz");
        }
        
    }
}
