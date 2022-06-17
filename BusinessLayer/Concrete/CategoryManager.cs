using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate.Repositories;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {

        IRepository<Category> _repository;

        public CategoryManager(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public void CatagoryDeleteBl(Category category)
        {
            _repository.Delete(category);
           
        }

        public void CategoryAddBl(Category category)
        {
            _repository.Add(category);
            
        }

        public void CategoryUpdate(Category category)
        {
            _repository.Update(category);
        }

        public Category GetById(int id)
        {
            return _repository.Get(x => x.CategoryId == id);
        }

        public List<Category> GetCategoryListBl()
        {
            return _repository.List();

        }
    }
}

