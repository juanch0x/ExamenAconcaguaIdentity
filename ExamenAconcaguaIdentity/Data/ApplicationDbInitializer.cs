using ExamenAconcaguaIdentity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenAconcaguaIdentity.Data
{
    public static class ApplicationDbInitializer
    {
        public static void SeedUsers(UserManager<User> userManager)
        {
            if (userManager.FindByEmailAsync("jportugal1992@gmail.com").Result == null)
            {
                User user = new User
                {
                    UserName = "jportugal1992@gmail.com",
                    Email = "jportugal1992@gmail.com"
                };

                IdentityResult result = userManager.CreateAsync(user, "admin").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}
