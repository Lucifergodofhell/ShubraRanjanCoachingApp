using System.ComponentModel.DataAnnotations;
using ShubraRanjanAPI.Entities.AssociationTable;

namespace ShubraRanjanAPI.Entities;
public class Subject
{
   public int SubjectId { get; set; }
   [Required]
   public required string SubjectName { get; set; }

   public ICollection<CourseSubject> CourseSubjects { get; set; } = new List<CourseSubject>();
   public ICollection<TeacherProfile> TeacherProfiles { get; set; } = new List<TeacherProfile>();
}