using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyNutrition.DataModels.Models
{
    public class IngredientAmount
    {
        [Key, Column(Order = 0)]
        public int IngredientId { get; set; }

        [ForeignKey("IngredientId")]
        public virtual Ingredient Ingredient { get; set; }

        [Key, Column(Order = 1)]
        public int RecipeId { get; set; }

        [ForeignKey("RecipeId")]
        public virtual Recipe Recipe { get; set; }

        public int ServingSize { get; set; }
    }
}
