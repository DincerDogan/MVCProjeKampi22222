using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public class ContentManager : IContentService
    {
        IRepository<Content> _repository;
        Context context = new Context();


        public ContentManager(IRepository<Content> repository)
        {
            _repository = repository;
        }

        public void ContentAdd(Content content)
        {
            _repository.Add(content);
        }

        public int ContentCount()
        {
            return _repository.List().Count();
        }

        public void ContentDelete(Content content)
        {
            throw new NotImplementedException();
        }

        public void ContentUpdate(Content content)
        {
            throw new NotImplementedException();
        }

        public Content GetById(string mail)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetContentList(string p)
        {
            return _repository.List(x=>x.ContentText.Contains(p));
        }

        public List<Content> GetContentListByDate()
        {
            return _repository.List().OrderByDescending(x => x.ContentTime).Take(15).ToList();
        }

        public List<Content> GetContentWriterList(int id)
        {
            return _repository.List(x => x.WriterId ==id);
        }

       

        public List<Content> GetListById(int id)
        {
            return _repository.List(x => x.HeadingId == id);
            
        }
    }
}
