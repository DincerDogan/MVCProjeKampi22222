using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public  interface IContentService
    {
        List<Content> GetContentList(string p );
        List<Content> GetContentListByDate();
        List<Content> GetContentWriterList(int id);
       
        List<Content> GetListById(int id);
     
        void ContentAdd(Content content);
        Content GetById(string mail);
        void ContentDelete(Content content);
        void ContentUpdate(Content content);
        int ContentCount();

    }
}
