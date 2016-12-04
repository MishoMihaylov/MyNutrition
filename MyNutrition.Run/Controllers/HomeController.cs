using MyNutrition.Run.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyNutrition.DataModels.Models;

namespace MyNutrition.Run.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            MyNutritionDbContext db = new MyNutritionDbContext();

            db.Protein.Add(new Protein());
            db.SaveChanges();

            return View();
        }
    }
}
