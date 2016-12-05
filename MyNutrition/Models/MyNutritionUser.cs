using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyNutrition.DataModels.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace MyNutrition.Models
{
    public class MyNutritionUser : IdentityUser
    {
        public MyNutritionUser() : base()
        {
            this.Recipes = new HashSet<Recipe>();
        }

        [StringLength(50)]
        public string PersonName { get; set; }

        [StringLength(50)]
        public string Town { get; set; }

        public string Address { get; set; }

        public int Phone { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreatedOn { get; set; }

        public ICollection<Recipe> Recipes { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<MyNutritionUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}