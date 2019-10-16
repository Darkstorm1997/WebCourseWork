using Microsoft.AspNetCore.Identity;
using NewsNow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsNow.Data
{
    public class NewsNowInititalizer
    {
        public static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByEmailAsync("admin@newsnow.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "admin@newsnow.com",
                    Email = "admin@newsnow.com"
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
