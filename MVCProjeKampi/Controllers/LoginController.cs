using BusinessLayer.Concrete;
using DataAccessLayer.Concreate;
using DataAccessLayer.Entityframework;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCProjeKampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        AdminManager adminManager = new AdminManager(new EFAdminDal());

        WriterLoginManager writerLoginManager = new WriterLoginManager(new EFWriterDal());
        WriterManager writerManager = new WriterManager(new EFWriterDal());

        [HttpGet]

        public ActionResult LoginIndex()
        {
            return View();
        }




        [HttpPost]
        public ActionResult LoginIndex(Admin admin)
        {
            string sifre = adminManager.MD5Create(admin.AdminPassword);
            admin.AdminPassword = sifre;
            var items = adminManager.GetById(admin);

            if (items != null)
            {
                FormsAuthentication.SetAuthCookie(items.AdminMail, false);
                Session["AdminMail"] = items.AdminMail;
                return RedirectToAction("HeadingIndex", "Heading");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();


        }

        [HttpPost]
        public ActionResult WriterLogin(Writer writer)

        {
            string sifre = adminManager.MD5Create(writer.WriterPassword);
            writer.WriterPassword = sifre;

            var info = writerLoginManager.GetWriter(writer.WriterMail, writer.WriterPassword);
            if (info != null)
            {

                FormsAuthentication.SetAuthCookie(info.WriterMail, info.RememberMe);
                Session["WriterMail"] = info.WriterMail;

                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return View();
            }


        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Vitrin");
        }

        [HttpGet]
        public ActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResetPassword(Writer writer)
        {

            var model = writerLoginManager.GetForPassword(writer);
            if (model != null)
            {
                Guid guid = Guid.NewGuid();
                model.WriterPassword = adminManager.MD5Create(guid.ToString().Substring(0,8));
               string newPassword = guid.ToString().Substring(0, 8);
                writerManager.WriterUpdate(model);
               
                SmtpClient client = new SmtpClient("smtp.yandex.ru", 587);
                client.EnableSsl = true;
                
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("GonderenMail", "Sifre degisikligi");
                mail.To.Add(model.WriterMail);
                mail.IsBodyHtml = true;
                mail.Subject = "Sifre degistirme istegi";
                mail.Body += "Merhaba " + model.WriterName + "<br/> Kullanici Adiniz=" + model.WriterTitle + "<br/> Sifreniz=" + newPassword;
                NetworkCredential networkCredential = new NetworkCredential("GonderenMail", "GonderenSifre");
                client.Credentials = networkCredential;
                client.Send(mail);
                ViewBag.success = "Yeni sifreniz e mail adresinize basarili bir sekilde gonderildi:)";
                return RedirectToAction("ConfirmPassword");
                

            }
            else
            {
                ViewBag.hata = "Boyle bir email adresi bulunamadı!!";
                return View();
            }

          


        }
        public ActionResult ConfirmPassword()
        {
            return View();
        }
    }
}






