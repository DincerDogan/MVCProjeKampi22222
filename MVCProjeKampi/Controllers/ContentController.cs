using BusinessLayer.Concrete;
using DataAccessLayer.Concreate;
using DataAccessLayer.Entityframework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager contentManager = new ContentManager(new EFContentDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContentByHeading(int id)
        {
            

            var items = contentManager.GetListById(id);
            
            return View(items);
        }

       
        public ActionResult GetAllContent(string p="")
        {
            var values = contentManager.GetContentList(p);
            
           // var items = context.Contents.ToList();
            return View(values);
        }
    }
}