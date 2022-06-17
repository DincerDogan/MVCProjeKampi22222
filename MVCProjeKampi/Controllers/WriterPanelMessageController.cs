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
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage
        MessageManager messageManager = new MessageManager(new EFMessageDal());
        MessageValidator validationRules = new MessageValidator();
        WriterManager writerManager = new WriterManager(new EFWriterDal());

        [HttpGet]
        public ActionResult MessageWriterInbox(string p,string text="")
        {
            p = (string)Session["WriterMail"];

            var items = messageManager.GetMessageInboxListBl(p).Where(x => x.MessageContent.Contains(text));


            return View(items);
        }
        [HttpPost]
        public ActionResult MessageWriterInbox(FormCollection form)
        {
            string[] ibs = form["MessageId"].Split(new char[] { ',' });
            foreach (var item in ibs)
            {
                messageManager.DeleteByCheckBox(int.Parse(item));


            }





            return RedirectToAction("MessageWriterInbox");
        }

        [HttpGet]
        public ActionResult MessageWriterSendBox(string p,string text="")
        {
            p = (string)Session["WriterMail"];

            var items = messageManager.GetMessageSendListBl(p).Where(x => x.MessageContent.Contains(text));
            return View(items);
        }

        [HttpPost]
        public ActionResult MessageWriterSendBox(FormCollection form)
        {
            string[] ibs = form["MessageId"].Split(new char[] { ',' });
            foreach (var item in ibs)
            {
                messageManager.DeleteByCheckBox(int.Parse(item));


            }





            return RedirectToAction("MessageWriterSendbox");
        }

        public ActionResult GetInboxWriterDetails(int id)
        {
            var Values = messageManager.GetById(id);
            return View(Values);
        }
        public ActionResult GetSendWriterDetails(int id)
        {
            var Values = messageManager.GetById(id);
            return View(Values);
        }

        public PartialViewResult MessageListMenu()
        {
            string mail = (string)Session["WriterMail"];
            var result = messageManager.InboxCount(mail);
            ViewBag.inbox = result;
            var result2 = messageManager.SendBoxCount(mail);
            ViewBag.sendbox = result2;
            return PartialView();
        }

        [HttpGet]

        public ActionResult NewMessageWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessageWriter(Message message)
        {
           string sender= (string)Session["WriterMail"];
            ValidationResult results = validationRules.Validate(message);
            if (results.IsValid)
            {
                message.SenderMail = sender; 
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.MEssageAddBl(message);
                return RedirectToAction("MessageWriterSendBox");
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
    }
}