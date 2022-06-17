using MVCProjeKampi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
           
            return View();
        }
        public ContentResult JSON()
        {
           
            JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
            return Content(JsonConvert.SerializeObject(BlogList(), _jsonSetting), "application/json");
        }
      
        public List<CategoryChart> BlogList()
        {
            List<CategoryChart> categoryCharts = new List<CategoryChart>();
            categoryCharts.Add(new CategoryChart()
            {
                CategoryName="Yazılım",
                CategoryCount=8


            });
            categoryCharts.Add(new CategoryChart()
            {

                CategoryCount=4,
                CategoryName="Spor"
            });
            categoryCharts.Add(new CategoryChart()
            {

                CategoryCount = 7,
                CategoryName = "Film"
            });
            categoryCharts.Add(new CategoryChart()
            {

                CategoryCount = 9,
                CategoryName = "Dizi"
            });

            return categoryCharts;
        }
    }
}