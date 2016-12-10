using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyNutrition.DataModels.Models
{
    public class DayConsumation
    {
        public DayConsumation()
        {
            this.ConsumedIngredients = new HashSet<DayConsumptionIngredient>();
            this.ConsumedRecipes = new HashSet<DayConsumationRecipe>();
        }

        public int Id { get; set; }

        [Index(IsUnique = true)]
        public DateTime Date { get; set; }

        public virtual ICollection<DayConsumptionIngredient> ConsumedIngredients { get; set; }

        public virtual ICollection<DayConsumationRecipe> ConsumedRecipes { get; set; }
    }
}
