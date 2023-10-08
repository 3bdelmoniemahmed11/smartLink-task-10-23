using Microsoft.AspNetCore.Identity;
using smartLinkTask.DAL.Models.UserProfileEntity;

namespace smartLinkTask.Core
{
    public static class Common
    {
        public static async Task SeedDataAsync(WebApplication app)
        {

            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                var roles = new[] { "HR", "Normal" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserProfile>>();
                string email = "admin@admin.com";
                string password = "Abc@123";
             

                if (await userManager.FindByEmailAsync(email) == null)
                {
                    var user = new UserProfile();
                    user.UserName = email;
                    user.Email = email;
                   
                    await userManager.CreateAsync(user, password);

                    await userManager.AddToRoleAsync(user, "HR");
                }
            }

        }
    }
}
