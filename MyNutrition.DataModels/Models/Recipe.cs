using System;
using System.Collections.Generic;

namespace MyNutrition.DataModels.Models
{
    public class Recipe
    {
        //Add picture

        public Recipe()
        {
            this.Ingredients = new HashSet<Ingredient>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int PreparationTime { get; set; }
               
        public int CookingTime { get; set; }

        public int ServingSize { get; set; }

        public string Description { get; set; }

        public RecipeType RecipeType { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}

//TODO
//-- Recipe Comments
//-- Recipe Rating
