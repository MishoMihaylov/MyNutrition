using System;

namespace MyNutrition.DataModels.Models
{
    public class FattyAcids
    {
        public int Id { get; set; }

        public float Omega3 { get; set; }

        public float Omega6 { get; set; }

        public int Overall
        {
            get { return (int) (this.Omega3 + this.Omega6); }
        }
    }
}
