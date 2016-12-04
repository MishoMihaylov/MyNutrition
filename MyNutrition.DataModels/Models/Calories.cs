using System;

namespace MyNutrition.DataModels.Models
{
    public class Calories
    {
        public int Id { get; set; }

        public float FromCarbohydrate { get; set; }

        public float FromFats { get; set; }

        public float FromProtein { get; set; }

        public float FromAlcohol { get; set; }
    }
}
