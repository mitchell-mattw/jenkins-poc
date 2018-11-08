using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver;
using RealEstate.Properties;
using RealEstate.App_Start;

namespace RealEstate.Controllers
{
    public class HomeController : Controller
    {
        public RealEstateContext Context = new RealEstateContext(); 
        public HomeController()
        {
                                   
        }
        public ActionResult Index()
        {
           var db = Context.Database.Client.GetDatabase("realestate");
           return Json(db.Settings, JsonRequestBehavior.AllowGet);
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}