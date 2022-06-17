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
    public class WriterManager : IWriterService
    {
        IRepository<Writer> _repository;

        public WriterManager(IRepository<Writer> repository)
        {
            _repository = repository;
        }

        public Writer GetById(int id)
        {
            return _repository.Get(x=>x.WriterId==id);
        }

        public Writer GetByIdWriter(Writer writer)
        {
            return _repository.Get(x=>x.WriterMail==writer.WriterMail && x.WriterPassword==writer.WriterPassword);
        }

        public int GetByWriterEmailId(string mail)
        {
            return _repository.List(x => x.WriterMail == mail).Select(y => y.WriterId).FirstOrDefault();
        }

        public List<Writer> GetWriterList()
        {
           return _repository.List();
        }

        public void WriterAdd(Writer writer)
        {
            _repository.Add(writer);
        }

        public void WriterDelete(Writer writer)
        {
            _repository.Delete(writer);
        }

        public void WriterUpdate(Writer writer)
        {
            _repository.Update(writer);
        }
    }
}
