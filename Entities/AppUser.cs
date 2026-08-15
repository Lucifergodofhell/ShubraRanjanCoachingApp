using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ShubraRanjanAPI.Entities;

public class AppUser:IdentityUser
{
   [Required]
   public required string FirstName { get; set; }
   [Required]
   public required string  LastName { get; set; }
   public string? RefreshToken { get; set; }
   public DateTime? RefreshTokenExpiry { get; set; }
   public StudentProfile StudentProfile { get; set; }
   public TeacherProfile TeacherProfile { get; set; }
}