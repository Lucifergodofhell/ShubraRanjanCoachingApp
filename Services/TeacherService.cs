using ShubraRanjanAPI.DTOs;
using ShubraRanjanAPI.Entities;
using ShubraRanjanAPI.Interface.RepositoryInterface;
using ShubraRanjanAPI.Interface.ServiceInterface;

public class TeacherService(IAccountRepositories accountRepositories,
                              IAccountServices accountServices,
                              ITeacherRepository teacherRepository) : ITeacherServices
{
   public async Task<bool> IsUserExist(string email)
   {
      return await accountRepositories.IsUserExist(email);
   }

   public async  Task<(UserDto, string?)> Login(LoginDto loginDtos)
   {
      return await accountServices.Login(loginDtos);
   }

   public async Task<TeacherProfileDto?> Register(TeacherRegisterDto registerDto)
   {
      var teacherProfile = await teacherRepository.Register(registerDto);
      if (teacherProfile != null)
      {
         return teacherProfile;
      }
      return null!;
   }
}
