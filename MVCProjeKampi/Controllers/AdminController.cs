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
    public class AdminController : Controller
    {
        // GET: Admin
        AdminManager adminManager = new AdminManager(new EFAdminDal());
        public ActionResult Index()
        {
            var items = adminManager.GetAdminListBl();
            return View(items);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            string sifre = adminManager.MD5Create(admin.AdminPassword);
            admin.AdminPassword = sifre;
            adminManager.AdminAddBl(admin);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            List<SelectListItem> selectListItems = (from x in adminManager.GetAdminListBl()

                                                    select new SelectListItem
                                                    {
                                                        Text = x.AdminRole,
                                                        Value = x.AdminId.ToString()

                                                    }
                                                  ).ToList();
            ViewBag.roles = selectListItems;
            var item = adminManager.GetByIdEdit(id);
            return View(item);
        }

        [HttpPost]
        public ActionResult EditAdmin(Admin admin)
        {
            string sifre = adminManager.MD5Create(admin.AdminPassword);
            admin.AdminPassword = sifre;
            adminManager.AdminUpdate(admin);
            return RedirectToAction("Index");
        }
    }
}