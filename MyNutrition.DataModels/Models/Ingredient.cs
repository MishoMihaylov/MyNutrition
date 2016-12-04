using System.Collections.Generic;

namespace MyNutrition.DataModels.Models
{
    public class Ingredient
    {
        //Add Picture

        public int Id { get; set; }

        public string Name { get; set; }

        public int BaseServingSize { get; set; }  //For 100 grams

        public Calories Calories { get; set; }

        public Protein Protein { get; set; }

        public Carbohydrates Carbohydrates { get; set; }

        public Fats Fats { get; set; }

        public FattyAcids FattyAcids { get; set; }

        public Vitamins Vitamins { get; set; }

        public Minerals Minerals { get; set; }

        public Sterols Sterols { get; set; }

        public Other Other { get; set; }

        public virtual ICollection<ServingSize> ServingSize { get; set; }

        public IngredientType IngredientType { get; set; }

        public Recipe Recipe { get; set; }
    }
}
