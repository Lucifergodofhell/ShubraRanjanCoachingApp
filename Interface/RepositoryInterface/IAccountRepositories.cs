using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShubraRanjanAPI.DTOs;
using ShubraRanjanAPI.Entities;

namespace ShubraRanjanAPI.Interface.RepositoryInterface;


public interface IAccountRepositories
{
   Task<(AppUser?,StudentProfileDto)>  Register(RegisterDto registerDto);
   Task<(AppUser?,object)>  Login(LoginDto  loginDto);
   Task<bool> IsUserExist(string Email);

   Task<IList<string>> GetUserRoles(AppUser user);

   Task<IdentityResult> UpdateUser(AppUser appUser);
}