using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyNutrition.DataModels.Models
{
    public class Recipe
    {
        //Add picture

        public Recipe()
        {
            this.Ingredients = new HashSet<Ingredient>();
            this.IngredientAmounts = new HashSet<IngredientAmount>();
        }

        public int Id { get; set; }

        [Display(Name = "Recipe Title")]
        public string Name { get; set; }

        [Display(Name = "Preparation Time")]
        public int PreparationTime { get; set; }

        [Display(Name = "Cooking Time")]
        public int CookingTime { get; set; }

        [Display(Name = "Serves")]
        public int ServingSize { get; set; }

        [Display(Name = "Directions")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public RecipeType RecipeType { get; set; }

        [Display(Name = "Ingredients")]
        public ICollection<IngredientAmount> IngredientAmounts { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }

    }
}

//TODO
//-- Recipe Comments
//-- Recipe Rating
