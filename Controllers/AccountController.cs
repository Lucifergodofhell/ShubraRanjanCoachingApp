using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Mvc;
using ShubraRanjanAPI.DTOs;
using ShubraRanjanAPI.Interface.ServiceInterface;

public class AccountController(IAccountServices accountServices) : BaseController
{
   [HttpPost("register")]
   public async Task<ActionResult<UserDto?>> Register(RegisterDto registerDto)
   {
      bool isUserExist = await accountServices.IsUserExist(registerDto.Email);

      if (isUserExist)
      {
         return BadRequest("User with this email already Exist");
      }
      var (user,refreshToken) = await accountServices.Register(registerDto);
      if (user == null) return BadRequest("Registration failed.");
      SetRefreshTokenCookie(refreshToken);
      return user;
   }

   [HttpPost("login")]
   public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
   {
      var (user,refreshToken) = await accountServices.Login(loginDto);
      if (user==null)
      {
         return Unauthorized("Invalid email or password");
      }
      SetRefreshTokenCookie(refreshToken);
      return user;
   }

}