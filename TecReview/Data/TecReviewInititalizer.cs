using Microsoft.AspNetCore.Identity;
using System;
using TecReview.Models;

namespace TecReview.Data
{
    public class TecReviewInititalizer
    {
        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByEmailAsync("admin@TecReview.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "admin@TecReview.com",
                    Email = "admin@TecReview.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "123456").Result;

                if (result.Succeeded)
                {

                }
                else
                {
                    throw new Exception("Unable to create default user");
                }
            }
        }
    }
}
