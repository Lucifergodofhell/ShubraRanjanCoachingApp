

namespace ShubraRanjanAPI.Entities;

public class TeacherProfile
{
   public int TeacherId { get; set; }
   public required string  UserId { get; set; }
   public string?  Bio { get; set; }
   public DateTime HireDate { get; set; }=DateTime.UtcNow;
   public int?  SubjectId { get; set; }

   public AppUser AppUser { get; set; }
   public Subject Subject { get; set; }
}