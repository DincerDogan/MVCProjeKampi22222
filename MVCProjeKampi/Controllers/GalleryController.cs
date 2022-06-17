using BusinessLayer.Concrete;
using DataAccessLayer.Entityframework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        ImageFileManager ImageFileManager = new ImageFileManager(new EFImageFileDal());
        public ActionResult GalleryIndex()
        {
            var items = ImageFileManager.GetImageList();
            return View(items);
        }
    }
}