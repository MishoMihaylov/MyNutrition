namespace MyNutrition.DataModels.Models
{
    public class ServingSize
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Size { get; set; }

        public virtual Ingredient Ingredient { get; set; }
    }
}
