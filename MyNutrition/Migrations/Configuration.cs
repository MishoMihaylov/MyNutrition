using System;

namespace MyNutrition.Migrations
{
    using System.Data.Entity.Migrations;
    using System.IO;
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
            var vegetables = new IngredientType { Name = "vegetables"};
            var protein = new IngredientType { Name = "protein" };
            var fruits = new IngredientType { Name = "fruits" };
            var grains = new IngredientType { Name = "grains" };
            var dairy = new IngredientType { Name = "dairy" };

            context.IngredientTypes.AddOrUpdate(i => i.Name, new IngredientType[] { vegetables, protein, fruits, grains, dairy });
            context.SaveChanges();

            var bran = new Ingredient { Name = "bran", IngredientType = grains, BaseServingSize = 100 };
            var reisin = new Ingredient { Name = "reisin", IngredientType = fruits, BaseServingSize = 100 };
            var water = new Ingredient { Name = "water", BaseServingSize = 100 };
            var butter = new Ingredient { Name = "butter", IngredientType = dairy, BaseServingSize = 100 };
            var sugar = new Ingredient { Name = "sugar", BaseServingSize = 100 };
            var vegerableOil = new Ingredient { Name = "vegetable oil", BaseServingSize = 100 };
            var egg = new Ingredient { Name = "eggs", BaseServingSize = 1};
            var flour = new Ingredient { Name = "flour", IngredientType = grains, BaseServingSize = 100 };
            var bakingPowder = new Ingredient { Name = "baking powder", BaseServingSize = 100 };
            context.Ingredients.AddOrUpdate(i => i.Name, new Ingredient[] { bran, reisin, water, butter, sugar, vegerableOil, egg, flour, bakingPowder });
            context.SaveChanges();

            var recipe = new Recipe { Name = "Bran Muffins", PreparationTime = 30, CookingTime = 45, Description = "Lightly coat a muffin tin with 1/2-cup capacity cups with melted butter, and fit a pastry bag with a large tip (if desired). Set aside. (Editor's Note: Not sure if your muffin tins hold 1/2 cup? A good way to check is to start pouring a measured cup of water in, stop when it's full, and see how much is left in the measuring cup. When in doubt, underfill and pour any extra batter at the end into another mini loaf pan or ramekins.) Adjust the oven rack to the middle setting and preheat the oven to 350º F. Spread the bran on the baking sheet and toast for 6 to 8 minutes, stirring halfway through to make sure it doesn't burn. In a small saucepan, combine 1 cup of the raisins and 1 cup of water and simmer on low heat until the liquid has been absorbed, about 15 minutes. Place in a blender or in a food processor fitted with the steel blade, and process until puréed.l puréed. Pour the bran into a large bowl, add the buttermilk and remaining 1/2 cup water, and stir to combine. Stir in the raisin purée, orange zest, and brown sugar. Add the oil, the whole egg, and the egg white, mixing well to combine. Sift the flours, baking powder, baking soda, and salt into the raisin mixture. Add the remaining whole raisins and stir to combine. Fill the pastry bag half full and pipe or spoon the batter into the prepared muffin tins, mounding the batter slightly but taking care not to overfill. Bake for about 25 minutes, until the muffins are well-browned and firm to the touch.", ServingSize = 12, Ingredients = context.Ingredients.ToList(), Image = File.ReadAllBytes(@"D:\SoftUni\C-Sharp DB Fundamentals\Databases Advanced - Entity Framework\Course Project\MyNutrition\MyNutrition\Pictures\bran-muffins.jpg") };

            recipe.IngredientAmounts.Add(new IngredientAmount { IngredientId = 1, RecipeId = 1, Amount =  500 });
            recipe.IngredientAmounts.Add(new IngredientAmount { IngredientId = 2, RecipeId = 1, Amount = 20 });
            recipe.IngredientAmounts.Add(new IngredientAmount { IngredientId = 3, RecipeId = 1, Amount = 200 });
            recipe.IngredientAmounts.Add(new IngredientAmount { IngredientId = 4, RecipeId = 1, Amount = 100 });
            recipe.IngredientAmounts.Add(new IngredientAmount { IngredientId = 5, RecipeId = 1, Amount = 150 });
            recipe.IngredientAmounts.Add(new IngredientAmount { IngredientId = 6, RecipeId = 1, Amount = 30 });
            recipe.IngredientAmounts.Add(new IngredientAmount { IngredientId = 7, RecipeId = 1, Amount = 40 });
            recipe.IngredientAmounts.Add(new IngredientAmount { IngredientId = 8, RecipeId = 1, Amount = 1 });
            recipe.IngredientAmounts.Add(new IngredientAmount { IngredientId = 9, RecipeId = 1, Amount = 300 });

            context.Recipes.Add(recipe);
            context.SaveChanges();
        }
    }
}
