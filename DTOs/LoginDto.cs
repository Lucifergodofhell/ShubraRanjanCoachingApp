
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ShubraRanjanAPI.DTOs;

public class LoginDto
{
   [Required]
   [EmailAddress(ErrorMessage ="Please give a valid Email Address")]
   public required string Email { get; set; }

   [Required]
   public required string Password { get; set; }
}