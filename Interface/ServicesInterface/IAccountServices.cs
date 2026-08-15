using Microsoft.AspNetCore.Mvc;
using ShubraRanjanAPI.DTOs;
using ShubraRanjanAPI.Entities;

namespace ShubraRanjanAPI.Interface.ServiceInterface;

public interface IAccountServices
{
   Task<(UserDto,string?)> Register(RegisterDto registerDto);
   Task<(UserDto,string?)>  Login(LoginDto registerDto);
   Task<bool> IsUserExist(string Email);
   Task<string> SetRefreshToken(AppUser user);
}