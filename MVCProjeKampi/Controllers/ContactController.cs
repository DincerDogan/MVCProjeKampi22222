using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Entityframework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager contactManager = new ContactManager(new EFContactDal());
        MessageManager messageManager = new MessageManager(new EFMessageDal());
        ContactValidator contactValidator = new ContactValidator();
        ContentManager contentManager = new ContentManager(new EFContentDal());

        [HttpGet]
        public ActionResult ContactIndex(string p="")
        {
            var items = contactManager.GetContactListBl(p);
            return View(items);
        }

        [HttpPost]

        public ActionResult ContactIndex(FormCollection form)
        {
            string[] ibs = form["ContactId"].Split(new char[] { ',' });
            foreach (var item in ibs)
            {
                contactManager.DeleteByCheckbox(int.Parse(item));


            }





            return RedirectToAction("ContactIndex");
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValues = contactManager.GetById(id);
            return View(contactValues);
        }

        public PartialViewResult ContactDetailsPartial()
        {
            return PartialView();
        }
        public PartialViewResult MessageBoxPartial()
        {
            string mail = (string)Session["AdminMail"];
            var result = messageManager.InboxCount(mail);
            ViewBag.inboxadmin = result;
            var result2 = messageManager.SendBoxCount(mail);
            ViewBag.sendboxadmin = result2;
            var result3 = contactManager.ContactCount();
            ViewBag.contact = result3;
            return PartialView();
        }

        
    }
}