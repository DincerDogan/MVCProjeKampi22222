using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Entityframework;
using EntityLayer.Concreate;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class WriterController : Controller
    {
        // GET: Writer
        WriterManager writerManager = new WriterManager(new EFWriterDal());
        HeadingManager headingManager = new HeadingManager(new EFHeadingDal());
        WriterValidator validationRules = new WriterValidator();
        AdminManager adminManager = new AdminManager(new EFAdminDal());
        public ActionResult WriterIndex()
        {
            var writervalues = writerManager.GetWriterList();
            return View(writervalues);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            string sifre = adminManager.MD5Create(writer.WriterPassword);
            writer.WriterPassword = sifre;
          
            ValidationResult results = validationRules.Validate(writer);
            
            if (results.IsValid)
            {
                writerManager.WriterAdd(writer);
                return RedirectToAction("WriterIndex");
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
        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writervalue = writerManager.GetById(id);
            return View(writervalue);

        }
        [HttpPost]
        public ActionResult EditWriter(Writer writer)
        {
            string sifre = adminManager.MD5Create(writer.WriterPassword);
            writer.WriterPassword = sifre;
            ValidationResult results = validationRules.Validate(writer);
            if (results.IsValid)
            {
                writerManager.WriterUpdate(writer);
                return RedirectToAction("WriterIndex");
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
       public ActionResult HeadingOfWriters(int id=0)
        {
            var items = headingManager.GetHeadingListByWriterBl(id);

            return View(items);
        }
    }
}