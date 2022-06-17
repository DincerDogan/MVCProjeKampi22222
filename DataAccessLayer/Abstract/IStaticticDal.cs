using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
   public interface IStaticticDal
    {
        int GetCategory();
        int GetHeading();
        string GetCategoryName();
        int GetWriter();
        int GetCategoryStatus();

    }
}
