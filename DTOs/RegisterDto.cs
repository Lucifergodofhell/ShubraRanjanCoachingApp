
using System.ComponentModel.DataAnnotations;
using CloudinaryDotNet.Actions;

namespace ShubraRanjanAPI.DTOs;

public class RegisterDto
{
   [Required(ErrorMessage ="Email is required")]
   [EmailAddress(ErrorMessage ="Please give a valid email address")]
   public required string Email { get; set; }
   [Required]
   public required string FirstName { get; set; }
   [Required]
   public required  string LastName { get; set; }
   [Required]
   public required string  UserName { get; set; }
   public string?  PhoneNumber { get; set; }
   [Required]
   public required string Password { get; set; }
}