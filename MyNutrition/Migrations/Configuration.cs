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
            var vegetables = new IngredientType { Name = "vegetables" };
            var protein = new IngredientType { Name = "protein" };
            var fruits = new IngredientType { Name = "fruits" };
            var grains = new IngredientType { Name = "grains" };
            var dairy = new IngredientType { Name = "dairy" };

            context.IngredientTypes.AddOrUpdate(i => i.Name, new IngredientType[] { vegetables, protein, fruits, grains, dairy });
            context.SaveChanges();

            var bran = new Ingredient { Name = "bran", IngredientType = grains, BaseServingSize = 100 };
            bran.Calories = new Calories() { Overall = 25 };
            bran.Carbohydrates = new Carbohydrates() { DietaryFiber = 15, Starch = 20, Sugars = new Sugars() { Fructose = 50 } };
            bran.Fats = new Fats() { SaturatedFat = 25 };
            bran.Protein = new Protein() { Overall = 21 };
            bran.Vitamins = new Vitamins() { A = 0.2f, C = 0.5f };
            bran.Minerals = new Minerals() { Calcium = 0.13f, Copper = 0.22f, Magnesium = 0.2f };
            var reisin = new Ingredient { Name = "reisin", IngredientType = fruits, BaseServingSize = 100 };
            reisin.Calories = new Calories() { Overall = 25 };
            reisin.Carbohydrates = new Carbohydrates() { DietaryFiber = 22, Starch = 33, Sugars = new Sugars() { Galactose = 50 } };
            reisin.Fats = new Fats() { SaturatedFat = 11 };
            reisin.Protein = new Protein() { Overall = 21 };
            reisin.Vitamins = new Vitamins() { D = 0.1f, C = 0.5f };
            reisin.Minerals = new Minerals() { Manganese = 0.13f, Copper = 0.22f, Fluoride = 0.2f };
            var water = new Ingredient { Name = "water", BaseServingSize = 100 };
            water.Calories = new Calories() { Overall = 11 };
            water.Carbohydrates = new Carbohydrates() { DietaryFiber = 22, Starch = 33, Sugars = new Sugars() { Galactose = 50 } };
            water.Fats = new Fats() { SaturatedFat = 11 };
            water.Protein = new Protein() { Overall = 21 };
            water.Vitamins = new Vitamins() { K = 0.1f, B6 = 0.5f };
            water.Minerals = new Minerals() { Manganese = 0.13f, Phosphorus = 0.22f, Fluoride = 0.2f };
            var butter = new Ingredient { Name = "butter", IngredientType = dairy, BaseServingSize = 100 };
            butter.Calories = new Calories() { Overall = 332 };
            butter.Carbohydrates = new Carbohydrates() { DietaryFiber = 22, Starch = 33, Sugars = new Sugars() { Lactose = 76 } };
            butter.Fats = new Fats() { MonounsaturatedFat = 11 };
            butter.Protein = new Protein() { Overall = 45 };
            butter.Vitamins = new Vitamins() { E = 0.1f, B6 = 0.5f, Riboflavin = 0.4f, PantothenicAcid = 0.2f };
            butter.Minerals = new Minerals() { Manganese = 0.13f, Phosphorus = 0.22f, Fluoride = 0.2f };
            var sugar = new Ingredient { Name = "sugar", BaseServingSize = 100 };
            sugar.Calories = new Calories() { Overall = 332 };
            sugar.Carbohydrates = new Carbohydrates() { DietaryFiber = 22, Starch = 33, Sugars = new Sugars() { Lactose = 76 } };
            sugar.Fats = new Fats() { MonounsaturatedFat = 11 };
            sugar.Protein = new Protein() { Overall = 45 };
            sugar.Vitamins = new Vitamins() { E = 0.1f, B6 = 0.5f, Riboflavin = 0.4f, PantothenicAcid = 0.2f };
            sugar.Minerals = new Minerals() { Manganese = 0.13f, Phosphorus = 0.22f, Fluoride = 0.2f };
            var vegerableOil = new Ingredient { Name = "vegetable oil", BaseServingSize = 100 };
            vegerableOil.Calories = new Calories() { Overall = 332 };
            vegerableOil.Carbohydrates = new Carbohydrates() { DietaryFiber = 22, Starch = 33, Sugars = new Sugars() { Lactose = 76 } };
            vegerableOil.Fats = new Fats() { MonounsaturatedFat = 11 };
            vegerableOil.Protein = new Protein() { Overall = 45 };
            vegerableOil.Vitamins = new Vitamins() { E = 0.1f, B6 = 0.5f, Riboflavin = 0.4f, PantothenicAcid = 0.2f };
            vegerableOil.Minerals = new Minerals() { Manganese = 0.13f, Phosphorus = 0.22f, Fluoride = 0.2f };
            var egg = new Ingredient { Name = "eggs", BaseServingSize = 1};
            egg.Calories = new Calories() { Overall = 332 };
            egg.Carbohydrates = new Carbohydrates() { DietaryFiber = 22, Starch = 33, Sugars = new Sugars() { Lactose = 76 } };
            egg.Fats = new Fats() { MonounsaturatedFat = 11 };
            egg.Protein = new Protein() { Overall = 45 };
            egg.Vitamins = new Vitamins() { E = 0.1f, B6 = 0.5f, Riboflavin = 0.4f, PantothenicAcid = 0.2f };
            egg.Minerals = new Minerals() { Manganese = 0.13f, Phosphorus = 0.22f, Fluoride = 0.2f };
            var flour = new Ingredient { Name = "flour", IngredientType = grains, BaseServingSize = 100 };
            flour.Calories = new Calories() { Overall = 332 };
            flour.Carbohydrates = new Carbohydrates() { DietaryFiber = 22, Starch = 33, Sugars = new Sugars() { Lactose = 76 } };
            flour.Fats = new Fats() { MonounsaturatedFat = 11 };
            flour.Protein = new Protein() { Overall = 45 };
            flour.Vitamins = new Vitamins() { E = 0.1f, B6 = 0.5f, Riboflavin = 0.4f, PantothenicAcid = 0.2f };
            flour.Minerals = new Minerals() { Manganese = 0.13f, Phosphorus = 0.22f, Fluoride = 0.2f };
            var bakingPowder = new Ingredient { Name = "baking powder", BaseServingSize = 100 };
            bakingPowder.Calories = new Calories() { Overall = 332 };
            bakingPowder.Carbohydrates = new Carbohydrates() { DietaryFiber = 22, Starch = 33, Sugars = new Sugars() { Lactose = 76 } };
            bakingPowder.Fats = new Fats() { MonounsaturatedFat = 11 };
            bakingPowder.Protein = new Protein() { Overall = 45 };
            bakingPowder.Vitamins = new Vitamins() { E = 0.1f, B6 = 0.5f, Riboflavin = 0.4f, PantothenicAcid = 0.2f };
            bakingPowder.Minerals = new Minerals() { Manganese = 0.13f, Phosphorus = 0.22f, Fluoride = 0.2f };
            context.Ingredients.AddOrUpdate(i => i.Name, new Ingredient[] { bran, reisin, water, butter, sugar, vegerableOil, egg, flour, bakingPowder });
            context.SaveChanges();

            var recipe = new Recipe { Name = "Bran Muffins", PreparationTime = 30, CookingTime = 45, Description = "Lightly coat a muffin tin with 1/2-cup capacity cups with melted butter, and fit a pastry bag with a large tip (if desired). Set aside. (Editor's Note: Not sure if your muffin tins hold 1/2 cup? A good way to check is to start pouring a measured cup of water in, stop when it's full, and see how much is left in the measuring cup. When in doubt, underfill and pour any extra batter at the end into another mini loaf pan or ramekins.) Adjust the oven rack to the middle setting and preheat the oven to 350º F. Spread the bran on the baking sheet and toast for 6 to 8 minutes, stirring halfway through to make sure it doesn't burn. In a small saucepan, combine 1 cup of the raisins and 1 cup of water and simmer on low heat until the liquid has been absorbed, about 15 minutes. Place in a blender or in a food processor fitted with the steel blade, and process until puréed.l puréed. Pour the bran into a large bowl, add the buttermilk and remaining 1/2 cup water, and stir to combine. Stir in the raisin purée, orange zest, and brown sugar. Add the oil, the whole egg, and the egg white, mixing well to combine. Sift the flours, baking powder, baking soda, and salt into the raisin mixture. Add the remaining whole raisins and stir to combine. Fill the pastry bag half full and pipe or spoon the batter into the prepared muffin tins, mounding the batter slightly but taking care not to overfill. Bake for about 25 minutes, until the muffins are well-browned and firm to the touch.", ServingSize = 12, Ingredients = context.Ingredients.ToList(), Image = File.ReadAllBytes(@"D:\Software Engineering Folder\GitHub\MyNutrition\trunk\MyNutrition\Pictures\bran-muffins.jpg") };
            var recipeBrulee = new Recipe { Name = "Brulee", PreparationTime = 50, CookingTime = 45, Description = "Толумбичките се правят по стара рецепта на баба...която е тайна...", ServingSize = 12, Ingredients = context.Ingredients.ToList(), Image = File.ReadAllBytes(@"D:\Software Engineering Folder\GitHub\MyNutrition\trunk\MyNutrition\Pictures\brulee.jpg") };
            var recipeCake = new Recipe { Name = "Chocolate Cake", PreparationTime = 15, CookingTime = 45, Description = "Толумбичките се правят по стара рецепта на баба...която е тайна...", ServingSize = 12, Ingredients = context.Ingredients.ToList(), Image = File.ReadAllBytes(@"D:\Software Engineering Folder\GitHub\MyNutrition\trunk\MyNutrition\Pictures\chokolate_cake.jpg") };
            var recipeTolumbichki = new Recipe { Name = "Tolumbichki", PreparationTime = 22, CookingTime = 45, Description = "Толумбичките се правят по стара рецепта на баба...която е тайна...", ServingSize = 12, Ingredients = context.Ingredients.ToList(), Image = File.ReadAllBytes(@"D:\Software Engineering Folder\GitHub\MyNutrition\trunk\MyNutrition\Pictures\tolumbichki.jpg") };

            recipe.IngredientAmounts.Add(new IngredientAmount { IngredientId = 1, RecipeId = 1, ServingSize =  500 });
            recipe.IngredientAmounts.Add(new IngredientAmount { IngredientId = 2, RecipeId = 1, ServingSize = 20 });
            recipe.IngredientAmounts.Add(new IngredientAmount { IngredientId = 3, RecipeId = 1, ServingSize = 200 });
            recipe.IngredientAmounts.Add(new IngredientAmount { IngredientId = 4, RecipeId = 1, ServingSize = 100 });
            recipe.IngredientAmounts.Add(new IngredientAmount { IngredientId = 5, RecipeId = 1, ServingSize = 150 });
            recipe.IngredientAmounts.Add(new IngredientAmount { IngredientId = 6, RecipeId = 1, ServingSize = 30 });
            recipe.IngredientAmounts.Add(new IngredientAmount { IngredientId = 7, RecipeId = 1, ServingSize = 40 });
            recipe.IngredientAmounts.Add(new IngredientAmount { IngredientId = 8, RecipeId = 1, ServingSize = 1 });
            recipe.IngredientAmounts.Add(new IngredientAmount { IngredientId = 9, RecipeId = 1, ServingSize = 300 });

            recipeBrulee.IngredientAmounts.Add(new IngredientAmount { IngredientId = 5, RecipeId = 2, ServingSize = 200 });
            recipeBrulee.IngredientAmounts.Add(new IngredientAmount { IngredientId = 3, RecipeId = 2, ServingSize = 150 });
            recipeBrulee.IngredientAmounts.Add(new IngredientAmount { IngredientId = 8, RecipeId = 2, ServingSize = 80 });

            recipeCake.IngredientAmounts.Add(new IngredientAmount { IngredientId = 5, RecipeId = 3, ServingSize = 121 });
            recipeCake.IngredientAmounts.Add(new IngredientAmount { IngredientId = 1, RecipeId = 3, ServingSize = 300 });
            recipeCake.IngredientAmounts.Add(new IngredientAmount { IngredientId = 7, RecipeId = 3, ServingSize = 150 });

            recipeTolumbichki.IngredientAmounts.Add(new IngredientAmount { IngredientId = 2, RecipeId = 4, ServingSize = 145 });
            recipeTolumbichki.IngredientAmounts.Add(new IngredientAmount { IngredientId = 8, RecipeId = 4, ServingSize = 120 });
            recipeTolumbichki.IngredientAmounts.Add(new IngredientAmount { IngredientId = 9, RecipeId = 4, ServingSize = 90 });

            context.Recipes.Add(recipe);
            context.Recipes.Add(recipeBrulee);
            context.Recipes.Add(recipeCake);
            context.Recipes.Add(recipeTolumbichki);

            context.SaveChanges();
        }
    }
}
