using Microsoft.AspNetCore.Identity;
using ShubraRanjanAPI.Entities;

public static class SeedData
{
   public static async Task InitializeData(IServiceProvider serviceProvider)
   {
      var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
      var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
      string[] roles = { "Admin", "Teacher", "Student" };
      foreach (var role in roles)
      {
         if (!await roleManager.RoleExistsAsync(role))
         {
            await roleManager.CreateAsync(new IdentityRole(role));
         }
      }
      string adminEmail = "ravikumardhal@gmail.com";  
      if (await userManager.FindByEmailAsync(adminEmail) == null)
      {
         var adminUser = new AppUser
         {
            UserName = "ruleroftheworld",
            Email = adminEmail,
            FirstName = "Ravi",
            LastName = "Dhal",
            EmailConfirmed = true,
         };

         var result = await userManager.CreateAsync(adminUser, "Admin@1234");
         if (result.Succeeded)
         {
            await userManager.AddToRoleAsync(adminUser, "Admin");
         }
      }
   }
}