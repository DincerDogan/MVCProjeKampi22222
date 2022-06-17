using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IRepository<About> _repository;

        public AboutManager(IRepository<About> repository)
        {
            _repository = repository;
        }

        public void AboutAddBl(About about)
        {
            _repository.Add(about);

        }

        public void AboutDeleteBl(About about)
        {
            _repository.Delete(about);
        }

        public void AboutUpdate(About about)
        {
            _repository.Update(about);
        }

        public List<About> GetAboutListBl()
        {
            return _repository.List();
        }

        public About GetById(int id)
        {
            return _repository.Get(x => x.AboutId == id);
        }
    }
}
