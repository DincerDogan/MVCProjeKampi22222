using BusinessLayer.Concrete;
using DataAccessLayer.Concreate;
using DataAccessLayer.Entityframework;
using MVCProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    [AllowAnonymous]
    public class VitrinController : Controller
    {
        // GET: Vitrin
        HeadingManager headingManager = new HeadingManager(new EFHeadingDal());
        ContentManager contentManager = new ContentManager(new EFContentDal());
        
       
        public ActionResult Headings()
        {

            var info = headingManager.GetHeadingListBl();
            

           
            
            return View(info);
        }
       
      
       
       
        
        public PartialViewResult Index(int id=0)
        {
            

            
            if (id!=0)
            {
                var contentList = contentManager.GetListById(id);
                return PartialView(contentList);
            }

            else
            {
                var contentdefaultlist = contentManager.GetContentListByDate();

                return PartialView(contentdefaultlist);
            }
            
        }
    }
}