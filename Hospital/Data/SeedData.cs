// SeedData.cs
using Hospital.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Hospital.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Seed roles
            await SeedRoles(roleManager);

            // Seed a default admin user
            await SeedAdminUser(userManager);
        }

        private static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "admin", "director", "doctor", "clinician", "matron", "nurse", "labManager", "labTechnician", "staff" };

            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

        private static async Task SeedAdminUser(UserManager<ApplicationUser> userManager)
        {
            var adminUser = new ApplicationUser
            {
                FirstName = "Admin",
                LastName = "User",
                UserName = "user@email.com",
                Email = "user@email.com",
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(adminUser, "User123!");

            if (result.Succeeded)
            {
                // Assign the admin role to the user
                await userManager.AddToRoleAsync(adminUser, "admin");
            }
        }
    }
}
