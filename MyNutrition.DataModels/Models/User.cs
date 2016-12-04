using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyNutrition.DataModels.Models
{
    public class User
    {
        //Add Picture

        public int Id { get; set; }

        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public virtual ICollection<Recipe> MyRecipes { get; set; }
    }
}
