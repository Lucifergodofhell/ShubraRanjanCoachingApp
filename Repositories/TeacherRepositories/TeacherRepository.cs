using Microsoft.AspNetCore.Identity;
using ShubraRanjanAPI.DTOs;
using ShubraRanjanAPI.Entities;
using ShubraRanjanAPI.Interface.RepositoryInterface;

public class TeacherRepository(UserManager<AppUser> userManager,AppDbContext context):ITeacherRepository
{
   public async Task<TeacherProfileDto?>  Register(TeacherRegisterDto teacherRegisterDto)
   {
      AppUser user = new AppUser
      {
         Email = teacherRegisterDto.Email,
         UserName = teacherRegisterDto.UserName,
         FirstName = teacherRegisterDto.FirstName,
         LastName = teacherRegisterDto.LastName,
         PhoneNumber = teacherRegisterDto.PhoneNumber,
      };
      var creteUser = await userManager.CreateAsync(user,teacherRegisterDto.Password);
      if (creteUser.Succeeded)
      {
         var addToRole = await userManager.AddToRoleAsync(user,"Teacher");
         if (addToRole.Succeeded)
         {
            TeacherProfile teacherProfile = new TeacherProfile
            {
               UserId = user.Id,
               Bio = teacherRegisterDto.Bio,
               SubjectId = teacherRegisterDto.SubjectId
            };
            context.TeacherProfiles.Add(teacherProfile);
            await context.SaveChangesAsync();
            return teacherProfile.ToDto();
         }
      }
      return null!;
   }
}