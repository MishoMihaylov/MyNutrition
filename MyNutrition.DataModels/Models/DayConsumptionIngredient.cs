namespace MyNutrition.DataModels.Models
{
    public class DayConsumptionIngredient
    {
        public int Id { get; set; }

        //Serving Size as grams
        public int ServingSize { get; set; }

        public Ingredient ConsumedIngredient { get; set; }
    }
}
