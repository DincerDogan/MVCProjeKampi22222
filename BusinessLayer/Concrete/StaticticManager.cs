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
    public class StaticticManager : IStatisticService
    {
        IStaticticDal _staticticDal;

        public StaticticManager(IStaticticDal staticticDal)
        {
            _staticticDal = staticticDal;
        }

        public int GetCategoryCount()
        {
            return _staticticDal.GetCategory();
        }

        public string GetCategoryName()
        {
            return _staticticDal.GetCategoryName();
        }

        public int GetCategoryStatusDifference()
        {
            return Math.Abs(_staticticDal.GetCategoryStatus());
        }

        public int GetHeadingCount()
        {
            return _staticticDal.GetHeading();
        }

        public int GetWriterCount()
        {
            return _staticticDal.GetWriter();
        }
    }
}
