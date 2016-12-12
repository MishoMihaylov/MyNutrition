using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyNutrition.DataModels.Models;
using MyNutrition.Models;

namespace MyNutrition.Controllers
{
    public class RecipesController : Controller
    {
        private MyNutritionDbContext db = new MyNutritionDbContext();

        // GET: Recipes
        public ActionResult Index(string searchString, string searchBy)
        {
            if (searchBy == "Ingredient")
            {
                return this.RedirectToAction("Index", "Ingredients", new { searchStr = searchString });
            }

            if (searchString != null)
            {
                return
                    this.View(this.db.Recipes.Where(r => r.Name.Contains(searchString)).Include(r => r.Ingredients));
            }

            return this.View(this.db.Recipes.Include(r => r.Ingredients).ToList());

        }

        // GET: Recipes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Include(r => r.IngredientAmounts).FirstOrDefault(r => r.Id == id);
            if (recipe == null)
            {
                return HttpNotFound();
            }

            ViewBag.IngredientAmounts = recipe.IngredientAmounts;

            var nutrients = this.CalculateNutritionValues(recipe);
            ViewBag.NutritionInfo = nutrients;

            return View(recipe);
        }

        // GET: Recipes/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Recipes/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Name,PreparationTime,CookingTime,ServingSize,Description")] Recipe recipe)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Recipes.Add(recipe);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(recipe);
        //}

        //// GET: Recipes/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Recipe recipe = db.Recipes.Find(id);
        //    if (recipe == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(recipe);
        //}

        //// POST: Recipes/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Name,PreparationTime,CookingTime,ServingSize,Description")] Recipe recipe)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(recipe).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(recipe);
        //}

        // GET: Recipes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipe recipe = db.Recipes.Find(id);
            db.Recipes.Remove(recipe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: Recipes/RecipeImage/
        public ActionResult RecipeImage(int id)
        {
            Recipe recipe = this.db.Recipes.Find(id);
            return this.View(recipe);
        }

        private Dictionary<string, int> CalculateNutritionValues(Recipe recipe)
        {
            var nutrients = new Dictionary<string, int>();
            nutrients.Add("Calories", 0);
            nutrients.Add("Protein", 0);
            nutrients.Add("Carbohidrates", 0);
            nutrients.Add("Saturated Fat", 0);
            nutrients.Add("Monounsaturated Fat", 0);
            nutrients.Add("Polyunsaturated Fat", 0);
            nutrients.Add("Fatty Acids", 0);
            nutrients.Add("Vitamin A", 0);
            nutrients.Add("Vitamin C", 0);
            nutrients.Add("Calcium", 0);
            nutrients.Add("Iron", 0);
            nutrients.Add("Magnesium", 0);

            foreach (var ingredient in recipe.IngredientAmounts)
            {
                double coefficient = ingredient.ServingSize / (double)ingredient.Ingredient.BaseServingSize;

                nutrients["Calories"] += ingredient.Ingredient.Calories != null ? (int)(ingredient.Ingredient.Calories.Overall * coefficient) : 0;
                nutrients["Protein"] += ingredient.Ingredient.Protein != null ? (int)(ingredient.Ingredient.Protein.Overall * coefficient) : 0;
                nutrients["Carbohidrates"] += ingredient.Ingredient.Carbohydrates != null ? (int)(ingredient.Ingredient.Carbohydrates.Overall * coefficient) : 0;

                if (ingredient.Ingredient.Fats != null)
                {
                    nutrients["Saturated Fat"] += (int)(ingredient.Ingredient.Fats.SaturatedFat * coefficient);
                    nutrients["Monounsaturated Fat"] += (int)(ingredient.Ingredient.Fats.MonounsaturatedFat * coefficient);
                    nutrients["Polyunsaturated Fat"] += (int)(ingredient.Ingredient.Fats.PolyunsaturatedFat * coefficient);
                }

                nutrients["Fatty Acids"] += ingredient.Ingredient.FattyAcids != null ? (int)(ingredient.Ingredient.FattyAcids.Overall * coefficient) : 0;

                if (ingredient.Ingredient.Vitamins != null)
                {
                    nutrients["Vitamin A"] += (int)(ingredient.Ingredient.Vitamins.A * coefficient);
                    nutrients["Vitamin C"] += (int)(ingredient.Ingredient.Vitamins.C * coefficient);
                }

                if (ingredient.Ingredient.Minerals != null)
                {
                    nutrients["Calcium"] += (int)(ingredient.Ingredient.Minerals.Calcium * coefficient);
                    nutrients["Iron"] += (int)(ingredient.Ingredient.Minerals.Iron * coefficient);
                    nutrients["Magnesium"] += (int)(ingredient.Ingredient.Minerals.Magnesium * coefficient);
                }

            }

            var keys = nutrients.Keys.ToList();
            foreach (var key in keys)
            {
                nutrients[key] /= recipe.ServingSize;
            }

            return nutrients;
        }
    }
}