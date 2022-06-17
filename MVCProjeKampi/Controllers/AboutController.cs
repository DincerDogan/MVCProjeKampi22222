using BusinessLayer.Concrete;
using DataAccessLayer.Entityframework;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutManager aboutManager = new AboutManager(new EFAboutDal());
        public ActionResult AboutIndex()
        {
            var items = aboutManager.GetAboutListBl();

            return View(items);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            aboutManager.AboutAddBl(about);
            return RedirectToAction("AboutIndex");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}