using System;

namespace MyNutrition.DataModels.Models
{
    public class Sugars
    {
        public int Id { get; set; }

        public float Sucrose { get; set; }

        public float Glucose { get; set; }

        public float Fructose { get; set; }

        public float Lactose { get; set; }

        public float Maltose { get; set; }

        public float Galactose { get; set; }

        public int Overall => (int)(this.Sucrose + this.Glucose + this.Fructose + this.Lactose + this.Maltose + this.Galactose);
    }
}
