
using ShubraRanjanAPI.Entities.AssociationTable;


namespace ShubraRanjanAPI.Entities;
public class StudentProfile
{
   public int StudentId { get; set; }
   public required string  UserId { get; set; }

   public DateTime EnrolementDate { get; set; }=DateTime.UtcNow;

   public AppUser AppUser { get; set; }
   public ICollection<StudentCourse> StudentCourses { get; set; } =[];

}