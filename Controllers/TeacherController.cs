
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShubraRanjanAPI.DTOs;
using ShubraRanjanAPI.Interface.ServiceInterface;



[Authorize(Policy ="RequireAdminRole")]
public class TeacherController(ITeacherServices teacherServices) : BaseController
{
   [HttpPost("register")]
   public async Task<ActionResult<TeacherProfileDto?>> Register(TeacherRegisterDto teacherRegisterDto)
   {
      bool isUserExist = await teacherServices.IsUserExist(teacherRegisterDto.Email);
      if (isUserExist)
      {
         return BadRequest("User with this email already Exist");
      }
      var user = await teacherServices.Register(teacherRegisterDto);
      if (user == null) return BadRequest("Registration failed.");
      return user;
   }
}