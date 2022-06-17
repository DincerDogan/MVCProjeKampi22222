using BusinessLayer.Concrete;
using DataAccessLayer.Entityframework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityLayer.Concreate;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;
using DataAccessLayer.Concreate;
using System.Net.Mail;
using System.IO;
using System.Configuration;
using System.Net;

namespace MVCProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager messageManager = new MessageManager(new EFMessageDal());
        MessageValidator validationRules = new MessageValidator();

        [Authorize]
        
        [HttpGet]
        public ActionResult MessageInbox(string text="")
        {
            string mail = (string)Session["AdminMail"];

            var items = messageManager.GetMessageInboxListBl(mail).Where(x => x.MessageContent.Contains(text));

          
            


          
            
            return View(items);
        }

        [HttpPost]
        public ActionResult MessageInbox(FormCollection form)
        {
            

            string[] ibs = form["MessageId"].Split(new char[] { ',' });
            foreach (var item in ibs)
            {
                messageManager.DeleteByCheckBox(int.Parse(item));
                

            }





            return RedirectToAction("MessageInbox");
        }

        [HttpGet]
        public ActionResult SendBox(string text="")
        {
            string mail = (string)Session["AdminMail"];
            var items = messageManager.GetMessageSendListBl(mail).Where(x => x.MessageContent.Contains(text));
            return View(items);
        }

        [HttpPost]

        public ActionResult SendBox(FormCollection formCollection)
        {
            string[] ibs = formCollection["MessageId"].Split(new char[] { ',' });
            foreach (var item in ibs)
            {
                messageManager.DeleteByCheckBox(int.Parse(item));


            }





            return RedirectToAction("SendBox");

        }



        [HttpGet]
        public ActionResult NewMessage()
        {
           
          

            return View();
        }
        public ActionResult GetInboxDetails(int id)
        {
            var Values = messageManager.GetById(id);
            return View(Values);
        }
        public ActionResult GetSendDetails(int id)
        {
            var Values = messageManager.GetById(id);
            return View(Values);
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            
            string mail = (string)Session["AdminMail"];
            ValidationResult results = validationRules.Validate(message);
            if (results.IsValid)
            {
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                message.SenderMail = mail;
                messageManager.MEssageAddBl(message);
                return RedirectToAction("SendBox");
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