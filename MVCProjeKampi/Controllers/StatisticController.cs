using BusinessLayer.Concrete;
using DataAccessLayer.Entityframework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class StatisticController : Controller
    {
        StaticticManager staticticManager = new StaticticManager(new EFStaticticDal());
        public ActionResult Index()
        {
            var item = staticticManager.GetCategoryCount();
            ViewBag.dgr = item;
            var deger = staticticManager.GetWriterCount();
            ViewBag.writer = deger;
            var info = staticticManager.GetHeadingCount();
            ViewBag.heading = info;
            var status = staticticManager.GetCategoryStatusDifference();
            ViewBag.statusctgr = status;
            var category = staticticManager.GetCategoryName();
            ViewBag.ctgrname = category;
            return View();
        }
    }
}