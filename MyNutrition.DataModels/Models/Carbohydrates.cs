using System;

namespace MyNutrition.DataModels.Models
{
    public class Carbohydrates
    {
        public int Id { get; set; }

        public float DietaryFiber { get; set; }

        public float Starch { get; set; }

        public Sugars Sugars { get; set; }
    }
}
