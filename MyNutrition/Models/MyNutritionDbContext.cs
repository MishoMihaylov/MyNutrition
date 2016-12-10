using Microsoft.AspNet.Identity.EntityFramework;
using MyNutrition.DataModels.Models;
using System.Data.Entity;

namespace MyNutrition.Models
{

    public class MyNutritionDbContext : IdentityDbContext<MyNutritionUser>
    {
        public MyNutritionDbContext()
            : base("MyNutritionConnection", throwIfV1Schema: false)
        {
        }

        public static MyNutritionDbContext Create()
        {
            return new MyNutritionDbContext();
        }

        public DbSet<Calories> Calories { get; set; }

        public DbSet<Carbohydrates> Carbohydrates { get; set; }

        public DbSet<Fats> Fats { get; set; }

        public DbSet<FattyAcids> FattyAcids { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<IngredientType> IngredientTypes { get; set; }

        public DbSet<Minerals> Minerals { get; set; }

        public DbSet<Other> Other { get; set; }

        public DbSet<Protein> Protein { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<RecipeType> RecipeTypes { get; set; }

        public DbSet<ServingSize> ServingSize { get; set; }

        public DbSet<Sterols> Sterols { get; set; }

        public DbSet<Sugars> Sugars { get; set; }

        public DbSet<Vitamins> Vitamins { get; set; }

        public DbSet<IngredientAmount> IngredientAmounts { get; set; }
    }
}