using Microsoft.AspNetCore.Mvc;
using ShubraRanjanAPI.DTOs;
using ShubraRanjanAPI.Entities;

namespace ShubraRanjanAPI.Interface.ServiceInterface;

public interface ITeacherServices
{
   Task<TeacherProfileDto?> Register(TeacherRegisterDto registerDto);
   Task<(UserDto,string?)>  Login(LoginDto registerDto);
   Task<bool> IsUserExist(string Email);
}