using MyNutrition.DataModels.Models;
using MyNutrition.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyNutrition.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            MyNutritionDbContext db = new MyNutritionDbContext();

            db.Protein.Add(new Protein());
            db.SaveChanges();

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