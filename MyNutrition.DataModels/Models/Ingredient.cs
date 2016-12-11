using System.Collections.Generic;

namespace MyNutrition.DataModels.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Ingredient
    {
        private ICollection<ServingSize> servingSize;
        private ICollection<Recipe> recipes;

        public Ingredient()
        {
            this.servingSize = new HashSet<ServingSize>();
            this.recipes = new HashSet<Recipe>();
        }
        //Add Picture

        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Base Serving Size")]
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

        public virtual ICollection<ServingSize> ServingSize
        {
            get { return this.servingSize; }
            set { this.servingSize = value; }
        }

        public virtual ICollection<Recipe> Recipes
        {
            get { return this.recipes; }
            set { this.recipes = value; }
        }
    }
}
