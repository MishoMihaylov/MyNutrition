using System.Collections.Generic;

namespace MyNutrition.DataModels.Models
{
    public class Ingredient
    {
        public Ingredient()
        {
            this.ServingSize = new HashSet<ServingSize>();
            this.Recipes = new HashSet<Recipe>();
        }
        //Add Picture

        public int Id { get; set; }

        public string Name { get; set; }

        public int BaseServingSize { get; set; }  //For 100 grams

        public virtual Calories Calories { get; set; }
                
        public virtual Protein Protein { get; set; }
                
        public virtual Carbohydrates Carbohydrates { get; set; }
                
        public virtual Fats Fats { get; set; }
                
        public virtual FattyAcids FattyAcids { get; set; }
                
        public virtual Vitamins Vitamins { get; set; }
                
        public virtual Minerals Minerals { get; set; }
                
        public virtual Sterols Sterols { get; set; }
                
        public virtual Other Other { get; set; }
                
        public virtual IngredientType IngredientType { get; set; }

        public virtual ICollection<ServingSize> ServingSize { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
