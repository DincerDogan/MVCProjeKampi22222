using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IWriterService
    {
        List<Writer> GetWriterList();
        void WriterAdd(Writer writer);
        void WriterDelete(Writer writer);
        void WriterUpdate(Writer writer);
        int GetByWriterEmailId(string mail);

        Writer GetById(int id);
        

        Writer GetByIdWriter(Writer writer);


    }
}
