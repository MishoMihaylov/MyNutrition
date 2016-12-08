namespace MyNutrition.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DataModels.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MyNutrition.Models.MyNutritionDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "MyNutrition.Models.MyNutritionDbContext";
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MyNutrition.Models.MyNutritionDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //

            context.IngredientTypes.AddOrUpdate(
                new IngredientType {Name = "friut"},
                new IngredientType {Name = "nuts"},
                new IngredientType {Name = "vegetable"},
                new IngredientType {Name = "dairy"},
                new IngredientType {Name = "meat"}
            );
            context.SaveChanges();

            context.Ingredients.AddOrUpdate(
                new Ingredient {Name = "bran" },
                new Ingredient {Name = "reisin", IngredientType = context.IngredientTypes.First(i => i.Name == "fruit")},
                new Ingredient {Name = "water" },
                new Ingredient {Name = "buttermilk", IngredientType = context.IngredientTypes.First(i => i.Name == "dairy") },
                new Ingredient {Name = "sugar" },
                new Ingredient {Name = "vegetable oil" },
                new Ingredient {Name = "egg" },
                new Ingredient {Name = "flour" },
                new Ingredient {Name = "baking powder" }
                );
            context.SaveChanges();

            context.Recipes.AddOrUpdate(
              new Recipe { Name = "Bran Muffins", PreparationTime = 30, CookingTime = 45, Description = "Lightly coat a muffin tin with 1/2-cup capacity cups with melted butter, and fit a pastry bag with a large tip (if desired). Set aside. (Editor's Note: Not sure if your muffin tins hold 1/2 cup? A good way to check is to start pouring a measured cup of water in, stop when it's full, and see how much is left in the measuring cup. When in doubt, underfill and pour any extra batter at the end into another mini loaf pan or ramekins.) Adjust the oven rack to the middle setting and preheat the oven to 350º F. Spread the bran on the baking sheet and toast for 6 to 8 minutes, stirring halfway through to make sure it doesn't burn. In a small saucepan, combine 1 cup of the raisins and 1 cup of water and simmer on low heat until the liquid has been absorbed, about 15 minutes. Place in a blender or in a food processor fitted with the steel blade, and process until puréed.l puréed. Pour the bran into a large bowl, add the buttermilk and remaining 1/2 cup water, and stir to combine. Stir in the raisin purée, orange zest, and brown sugar. Add the oil, the whole egg, and the egg white, mixing well to combine. Sift the flours, baking powder, baking soda, and salt into the raisin mixture. Add the remaining whole raisins and stir to combine. Fill the pastry bag half full and pipe or spoon the batter into the prepared muffin tins, mounding the batter slightly but taking care not to overfill. Bake for about 25 minutes, until the muffins are well-browned and firm to the touch.", ServingSize = 12, Ingredients = context.Ingredients.ToList()}
            );

            context.SaveChanges();
        }
    }
}
