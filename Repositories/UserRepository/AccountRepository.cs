using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShubraRanjanAPI.DTOs;
using ShubraRanjanAPI.Entities;
using ShubraRanjanAPI.Interface.RepositoryInterface;

public class AccountRepositories(UserManager<AppUser> userManager,AppDbContext context) : IAccountRepositories
{
   public async Task<IList<string>> GetUserRoles(AppUser user)
   {
      return await userManager.GetRolesAsync(user);
   }

   public async Task<bool> IsUserExist(string email)
   {
     return await  userManager.FindByEmailAsync(email)!=null;
   }
   public async  Task<(AppUser?,object)> Login(LoginDto loginDto)
   {
      var user = await userManager.FindByEmailAsync(loginDto.Email);
      if (user==null)
      {
         return (null,null)!;
      }

      var isPasswordCorrect = await userManager.CheckPasswordAsync(user,loginDto.Password);
      
      if (!isPasswordCorrect)
      {
         return (null,null)!;
      }
      var roles = await userManager.GetRolesAsync(user);

      if (roles.Contains("Admin"))
      {
         return (user, null!);
      }
      else if (roles.Contains("Student"))
      {
         var studentProfile = await context.StudentProfiles.FirstOrDefaultAsync(s=>s.UserId.Equals(user.Id));
         return (studentProfile!=null)?(user,studentProfile.ToDto()):(null,studentProfile!);
      }
      var teacherProfile = await context.TeacherProfiles.FirstOrDefaultAsync(t=>t.UserId.Equals(user.Id));
      return (teacherProfile!=null)?(user,teacherProfile.ToDto()):(null,teacherProfile!);
   }
   public async Task<(AppUser?,StudentProfileDto)> Register(RegisterDto registerDto)
   {
      AppUser user = new AppUser
      {
         Email = registerDto.Email,
         UserName = registerDto.UserName,
         FirstName = registerDto.FirstName,
         LastName = registerDto.LastName,
         PhoneNumber = registerDto.PhoneNumber,
      };
      var creteUser = await userManager.CreateAsync(user,registerDto.Password);
      if (creteUser.Succeeded)
      {
         var addToRole = await userManager.AddToRoleAsync(user,"Student");
         if (addToRole.Succeeded)
         {
            StudentProfile studentProfile = new StudentProfile
            {
               UserId = user.Id
            };
            context.StudentProfiles.Add(studentProfile);
            await context.SaveChangesAsync();
            return (user,studentProfile.ToDto());
         }
      }
      return (null,null!);
   }

   public async Task<IdentityResult> UpdateUser(AppUser appUser)
   {
      return await userManager.UpdateAsync(appUser);
   }

   public async Task<IdentityResult> DeleteUser(AppUser appUser)
   {
      return await userManager.DeleteAsync(appUser);
   }
}