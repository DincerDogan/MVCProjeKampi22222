using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public  interface IAboutService
    {
        List<About> GetAboutListBl();
        void AboutAddBl(About about);

        About GetById(int id);
        void AboutDeleteBl(About about);

        void AboutUpdate(About about);
    }
}
