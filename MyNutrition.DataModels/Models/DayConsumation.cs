using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyNutrition.DataModels.Models
{
    public class DayConsumation
    {
        public DayConsumation()
        {
            this.Ingredients = new HashSet<Ingredient>();
            this.Recipes = new HashSet<Recipe>();
        }

        public int Id { get; set; }

        [Index(IsUnique = true)] //To be made for date only
        public virtual DateTime Date { get; set; }

        public virtual Protein DayProteins { get; set; }

        public virtual Calories DayCalories { get; set; }

        public virtual Carbohydrates DayCarbohydrates { get; set; }

        public virtual Fats DayFats { get; set; }

        public virtual Vitamins DayVitamins { get; set; }

        public virtual Minerals DayMinerals { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
