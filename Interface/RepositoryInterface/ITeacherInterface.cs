using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShubraRanjanAPI.DTOs;
using ShubraRanjanAPI.Entities;

namespace ShubraRanjanAPI.Interface.RepositoryInterface;


public interface ITeacherRepository
{
   Task<TeacherProfileDto?>  Register(TeacherRegisterDto registerDto);
}