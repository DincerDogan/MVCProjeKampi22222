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
   public  class WriterLoginManager:IWriterLoginService
    {
        IRepository<Writer> _repository;

        public WriterLoginManager(IRepository<Writer> repository)
        {
            _repository = repository;
        }

        public Writer GetForPassword(Writer writer)
        {
            return _repository.Get(x => x.WriterMail == writer.WriterMail);
        }

        public Writer GetWriter(string username, string password)
        {
            return _repository.Get(x => x.WriterMail == username && x.WriterPassword == password);
        }
    }
}
