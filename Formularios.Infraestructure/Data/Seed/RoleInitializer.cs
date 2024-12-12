using Formularios.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Formularios.Infraestructure.Data.Seed
{
    public static class RoleInitializer
    {
        public static async Task InitializeAsync(RoleManager<ApplicationRole> roleManager)
        {
            var roles = new[] { "Admin", "User" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new ApplicationRole { Name = role });
                }
            }
        }
    }
}
