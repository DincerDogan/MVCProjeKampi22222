using BusinessLayer.Concrete;
using DataAccessLayer.Concreate;
using DataAccessLayer.Entityframework;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;

namespace MVCProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager headingManager = new HeadingManager(new EFHeadingDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        WriterManager writerManager = new WriterManager(new EFWriterDal());
        WriterValidator validationRules = new WriterValidator();
        AdminManager adminManager = new AdminManager(new EFAdminDal());
        [HttpGet]
        public ActionResult WriterProfile(int id=0)
        {
            string mail = (string)Session["WriterMail"];
            id = writerManager.GetByWriterEmailId(mail);
           
            var items = writerManager.GetById(id);
           

            return View(items);
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            string sifre = adminManager.MD5Create(writer.WriterPassword);
            writer.WriterPassword = sifre;
            ValidationResult results = validationRules.Validate(writer);
            if (results.IsValid)
            {
                writerManager.WriterUpdate(writer);
                return RedirectToAction("/AllHeading/WriterPanel/");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);


                }
                return View();
            }




        }

        public ActionResult MyHeading(string mail)
        {
           
            mail = (string)Session["WriterMail"];
            int  writeridinfo = writerManager.GetByWriterEmailId(mail);
            var items = headingManager.GetHeadingListByWriterBl(writeridinfo);
            return View(items);
        } 

        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> selectListItems = (from x in cm.GetCategoryListBl()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.CategoryName,
                                                        Value = x.CategoryId.ToString()
                                                    }

                                                  ).ToList();
            ViewBag.dgr = selectListItems;
            return View();

        }
        [HttpPost]
        public ActionResult NewHeading(Heading heading )
        {
            string mail = (string)Session["WriterMail"];
            var writeridinfo = writerManager.GetByWriterEmailId(mail);
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterId = writeridinfo;          
            heading.HeadingStatus = true;
            headingManager.HeadingAddBl(heading);
            return RedirectToAction("MyHeading");

        }
        [HttpGet]
        public ActionResult EditWriterPanelHeading(int id)
        {
            List<SelectListItem> selectListItems = (from x in cm.GetCategoryListBl()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.CategoryName,
                                                        Value = x.CategoryId.ToString()
                                                    }

                                                 ).ToList();
            ViewBag.dgr = selectListItems;
            var items = headingManager.GetById(id);
            return View(items);
        }

        [HttpPost]
        public ActionResult EditWriterPanelHeading(Heading heading)
        {
            headingManager.HeadingUpdate(heading);
           
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteWriterPanelHeading(int id)
        {
            var headingvalue = headingManager.GetById(id);
            if (headingvalue.HeadingStatus == true)
            {
                headingvalue.HeadingStatus = false;
            }
            else headingvalue.HeadingStatus = true;

            headingManager.HeadingDeleteBl(headingvalue);


            return RedirectToAction("MyHeading");

        }
        public ActionResult AllHeading(int page=1)
        {


            var items = headingManager.GetHeadingListBl().ToPagedList(page, 6);
            return View(items);
        }

        public PartialViewResult WriterInfo()
        {
            string mail = (string)Session["WriterMail"];
           int id = writerManager.GetByWriterEmailId(mail);

            var items = writerManager.GetById(id);
            ViewBag.img = items.WriterImage;
            ViewBag.name = items.WriterName;
            return PartialView();
        }
    }
}