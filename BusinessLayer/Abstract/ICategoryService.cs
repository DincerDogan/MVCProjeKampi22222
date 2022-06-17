using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetCategoryListBl();
        void CategoryAddBl(Category category);

        Category GetById(int id);
        void CatagoryDeleteBl(Category category);

        void CategoryUpdate(Category category);
        
    }
}
