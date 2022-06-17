using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
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
    [AllowAnonymous]
    public class HomeController : Controller
    {

        ContactManager contactManager = new ContactManager(new EFContactDal());
        HeadingManager headingManager = new HeadingManager(new EFHeadingDal());
        ContentManager contentManager = new ContentManager(new EFContentDal());
        WriterManager writerManager = new WriterManager(new EFWriterDal());
       


        [HttpGet]
        public ActionResult HomePage()
        {
            var headingcount = headingManager.GetHeadingListBl().Count();
            ViewBag.countofheading = headingcount;
            var contentcount = contentManager.ContentCount();
            ViewBag.countofcontent = contentcount;
            var writercount = writerManager.GetWriterList().Count();
            ViewBag.countofwriter = writercount;
            var contactcount = contactManager.ContactCount();
            ViewBag.countofcontact = contactcount;

            return View();
        }

        [HttpPost]
        public ActionResult HomePage(Contact contact)
        {
            ContactValidator validationRules = new ContactValidator();
            ValidationResult results = validationRules.Validate(contact);
            if (results.IsValid)
            {
                contact.ContactDate = DateTime.Now;
                contactManager.ContactAddBl(contact);
                return RedirectToAction("HomePage");
                
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);


                }

                return View("HomePage", "#contact");
            }
        }


       





    }
}