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
    public class HeadingManager : IHeadingService
    {
        IRepository<Heading> _repository;
        public HeadingManager(IRepository<Heading> repository)
        {
            _repository = repository;
        }

        public Heading GetById(int id)
        {
            return _repository.Get(x => x.HeadingId == id);
        }

        public List<Heading> GetHeadingListBl()
        {
            return _repository.List();
        }

        public List<Heading> GetHeadingListByWriterBl(int id)
        {
            return _repository.List(x=>x.WriterId==id);
        }

        public void HeadingAddBl(Heading heading)
        {
            _repository.Add(heading);
        }

        public void HeadingDeleteBl(Heading heading)
        {
           
            _repository.Update(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            _repository.Update(heading);
        }
    }
}
