using System;
using System.Collections.Generic;

namespace MyNutrition.DataModels.Models
{
    public class Recipe
    {
        //Add picture

        public int Id { get; set; }

        public string Name { get; set; }

        public User RecipeAuthor { get; set; }

        public DateTime PreparationTime { get; set; }

        public DateTime CookingTime { get; set; }

        public int ServingSize { get; set; }

        public string Description { get; set; }

        public RecipeType RecipeType { get; set; }

        public virtual IEnumerable<Ingredient> Ingredients { get; set; }
    }
}

//TODO
//-- Recipe Comments
//-- Recipe Rating
