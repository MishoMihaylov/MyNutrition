namespace MyNutrition.DataModels.Models
{
    public class DayConsumationRecipe
    {
        public int Id { get; set; }

        //ServingSize as portions
        public int ServingSize { get; set; }

        public Recipe ConsumedRecipe { get; set; }
    }
}
