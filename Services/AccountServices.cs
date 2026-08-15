
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShubraRanjanAPI.DTOs;
using ShubraRanjanAPI.Entities;
using ShubraRanjanAPI.Interface.RepositoryInterface;
using ShubraRanjanAPI.Interface.ServiceInterface;

public class AccountServices(IAccountRepositories accountRepositories,ITokenServices tokenServices):IAccountServices
{
   public async Task<(UserDto, string?)> Login(LoginDto loginDto)
   {
      var (user,profile) =  await accountRepositories.Login(loginDto);
      if (user != null)
      {
         var refreshToken = await SetRefreshToken(user);
         var userRole = await accountRepositories.GetUserRoles(user);
         var result = await user.ToUserDto(tokenServices,userRole.FirstOrDefault()!,profile);
         return (result,refreshToken);
      }
      return (null,null)!;
   }
   public async Task<(UserDto,string?)> Register(RegisterDto registerDto )
   {
      var (user,studentProfile) = await accountRepositories.Register(registerDto);
      if (user != null)
      {
         var refreshToken = await SetRefreshToken(user);
         var userRole = await accountRepositories.GetUserRoles(user);
         var result = await user.ToUserDto(tokenServices,userRole.FirstOrDefault()!,studentProfile);
         return (result,refreshToken);
      }
      return (null,null)!;
   }
    public async Task<bool> IsUserExist(string email)
   {
      return await accountRepositories.IsUserExist(email);
   }

   public async Task<string> SetRefreshToken(AppUser user)
   {
      var refreshToken = tokenServices.GenerateRefreshTokenToken();
      user.RefreshToken = refreshToken;
      user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);
      await accountRepositories.UpdateUser(user);
      return refreshToken; 
   }
}