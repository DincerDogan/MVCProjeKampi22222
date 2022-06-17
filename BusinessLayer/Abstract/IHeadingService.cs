using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IHeadingService
    {
        List<Heading> GetHeadingListBl();
        List<Heading> GetHeadingListByWriterBl(int id);
        void HeadingAddBl(Heading heading);


        Heading GetById(int id);
        void HeadingDeleteBl(Heading heading);

        void HeadingUpdate(Heading heading);
    }
}
