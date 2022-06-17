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
    public class AdminCategoryController : Controller
    {
        // GET: AdminCategory
        CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());

        [Authorize(Roles ="B")]
        public ActionResult Index()

        {
            var items=categoryManager.GetCategoryListBl();
            return View(items);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator validationRules = new CategoryValidator();
            ValidationResult results = validationRules.Validate(category);
            if (results.IsValid)
            {
                categoryManager.CategoryAddBl(category);
                return RedirectToAction("Index");
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

        public ActionResult DeleteCategory(int id)
        {
            var item = categoryManager.GetById(id);
            
            categoryManager.CatagoryDeleteBl(item);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var item = categoryManager.GetById(id);
            return View(item);
        }
        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            categoryManager.CategoryUpdate(category);
            return RedirectToAction("Index");
        }

    }
}