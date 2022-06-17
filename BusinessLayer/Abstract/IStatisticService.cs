using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IStatisticService
    {
        int GetCategoryCount();
        int GetHeadingCount();
        int GetWriterCount();

        string GetCategoryName();

        int GetCategoryStatusDifference();

    }
}
