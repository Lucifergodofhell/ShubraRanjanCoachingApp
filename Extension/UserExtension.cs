using ShubraRanjanAPI.DTOs;
using ShubraRanjanAPI.Entities;

public static class UserExtension
{
   public static async Task<UserDto>ToUserDto(this AppUser user,ITokenServices tokenServices,string userRole,object profile)
   {
      return new UserDto
      {
         Id = user.Id,
         Email= user.Email!,
         FirstName = user.FirstName,
         LastName = user.LastName,
         UserName = user.UserName!,
         Role = userRole,
         ProfileData = profile,
         Token = await tokenServices.CreateToken(user),
      };

   }
}