namespace MyNutrition.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using DataModels.Models;
    using Models;

    public class IngredientsController : Controller
    {
        private MyNutritionDbContext db = new MyNutritionDbContext();

        // GET: Ingredients
        public ActionResult Index()
        {
            return this.View(this.db.Ingredients.ToList());
        }

        // GET: Ingredients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredient ingredient = this.db.Ingredients.Find(id);
            if (ingredient == null)
            {
                return this.HttpNotFound();
            }
            return this.View(ingredient);
        }

        // GET: Ingredients/Create
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: Ingredients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,BaseServingSize")] Ingredient ingredient)
        {
            if (this.ModelState.IsValid)
            {
                this.db.Ingredients.Add(ingredient);
                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(ingredient);
        }

        // GET: Ingredients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredient ingredient = this.db.Ingredients.Find(id);
            if (ingredient == null)
            {
                return this.HttpNotFound();
            }
            return this.View(ingredient);
        }

        // POST: Ingredients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,BaseServingSize")] Ingredient ingredient)
        {
            if (this.ModelState.IsValid)
            {
                this.db.Entry(ingredient).State = EntityState.Modified;
                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }
            return this.View(ingredient);
        }

        // GET: Ingredients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredient ingredient = this.db.Ingredients.Find(id);
            if (ingredient == null)
            {
                return this.HttpNotFound();
            }
            return this.View(ingredient);
        }

        // POST: Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ingredient ingredient = this.db.Ingredients.Find(id);
            this.db.Ingredients.Remove(ingredient);
            this.db.SaveChanges();
            return this.RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
