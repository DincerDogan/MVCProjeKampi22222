using BusinessLayer.Concrete;
using DataAccessLayer.Entityframework;
using EntityLayer.Concreate;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager headingManager = new HeadingManager(new EFHeadingDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        WriterManager wm = new WriterManager(new EFWriterDal());
        public ActionResult HeadingIndex(int page=1)
        {
            var headingvalues = headingManager.GetHeadingListBl().ToPagedList(page,6);
            return View(headingvalues);
            
        }
        public ActionResult HeadingReport()
        {
            var items = headingManager.GetHeadingListBl();
            return View(items);
        }

        [HttpGet]
        public ActionResult AddHeading()
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
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.HeadingStatus = true;
            heading.WriterId = 8;
            headingManager.HeadingAddBl(heading);
            return RedirectToAction("HeadingIndex");

        }

        [HttpGet]
        public ActionResult EditHeading(int id)
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
        public ActionResult EditHeading(Heading heading)
        {
            headingManager.HeadingUpdate(heading);
            return RedirectToAction("HeadingIndex");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingvalue = headingManager.GetById(id);
            if (headingvalue.HeadingStatus == true)
            {
                headingvalue.HeadingStatus = false;
            }
            else headingvalue.HeadingStatus = true;
           
            headingManager.HeadingDeleteBl(headingvalue);
          
            
            return RedirectToAction("HeadingIndex");

        }


        
    }
}