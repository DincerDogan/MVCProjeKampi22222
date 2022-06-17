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
    public class ImageFileManager : IImageFileService
    {
        IRepository<ImageFile> _repository;

        public ImageFileManager(IRepository<ImageFile> repository)
        {
            _repository = repository;
        }

        public List<ImageFile> GetImageList()
        {
            return _repository.List();
        }
    }
}
