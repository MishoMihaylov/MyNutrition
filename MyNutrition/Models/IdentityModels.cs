using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyNutrition.DataModels.Models;

namespace MyNutrition.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class MyNutritionUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<MyNutritionUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

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

        public DbSet<IngredientType> IngredientType { get; set; }

        public DbSet<Minerals> Minerals { get; set; }

        public DbSet<Other> Other { get; set; }

        public DbSet<Protein> Protein { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<RecipeType> RecipeTypes { get; set; }

        public DbSet<ServingSize> ServingSize { get; set; }

        public DbSet<Sterols> Sterols { get; set; }

        public DbSet<Sugars> Sugars { get; set; }

        public DbSet<Vitamins> Vitamins { get; set; }
    }
}