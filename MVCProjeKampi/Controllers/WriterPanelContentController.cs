using BusinessLayer.Concrete;
using DataAccessLayer.Concreate;
using DataAccessLayer.Entityframework;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager contentManager = new ContentManager(new EFContentDal());
        WriterManager writerManager = new WriterManager(new EFWriterDal());
        HeadingManager headingManager = new HeadingManager(new EFHeadingDal());
        
        public ActionResult MyContent(string p)
        {
           
            
            p = (string)Session["WriterMail"];
            var writerinfoid = writerManager.GetByWriterEmailId(p);
            var items = contentManager.GetContentWriterList(writerinfoid);
            return View(items);
        }
        [HttpGet]
        public ActionResult AddNewContent(int id)
        {
            ViewBag.dgr = id;
           
            return View();
        }
        [HttpPost]
        public ActionResult AddNewContent(Content content)
        {
            string mail = (string)Session["WriterMail"];
            var writeridinfo = writerManager.GetByWriterEmailId(mail);
            content.WriterId = writeridinfo;
            content.ContentTime = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.ContentStatus = true;
            contentManager.ContentAdd(content);
            return RedirectToAction("MyContent");
            
            
        }
    }
}