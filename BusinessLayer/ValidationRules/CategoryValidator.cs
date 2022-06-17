using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public  class CategoryValidator:AbstractValidator<Category>
    {
        
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adini Bos Gecemezsiniz");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Acıklamayı bos gecemezsiniz");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lutfen En az 3 karakter giriniz");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Lutfen 20 karakterdden fazla girmeyiniz");
        }
    }
}
