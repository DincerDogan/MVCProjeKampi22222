using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concreate.Repositories
{
    public class StaticticRepository : IStaticticDal
    {
        Context context = new Context();

        public int GetCategory()
        {
            return context.Categories.Count();
        }

        public string GetCategoryName()
        {


            var result = (from h in context.Headings
                          group h.Category.CategoryName by new { h.Category.CategoryName }
                         into g
                          orderby g.Count() descending

                          select new
                          {
                              g.Key.CategoryName

                          }

                         ).Take(1).SingleOrDefault().CategoryName;

            return result;

            

                      
                     




        }

        public int GetCategoryStatus()
        {
            var statustrue = context.Categories.Where(x => x.CategoryStatus == true).Count();
            var statusfalse = context.Categories.Where(x => x.CategoryStatus == false).Count();
            return (statustrue - statusfalse);
        }

        public int GetHeading()
        {
            return context.Headings.Where(x => x.Category.CategoryName == "Teknoloji").Count();
        }
            

        public int GetWriter()
        {
            return context.Writers.Where(x => x.WriterName.Contains("a")).Count();

        }
    }
}
