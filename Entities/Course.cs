using System.ComponentModel.DataAnnotations;
using ShubraRanjanAPI.Entities.AssociationTable;

namespace ShubraRanjanAPI.Entities;

public class Course
{
   public int CourseId { get; set; }
   [Required]
   public required string  CourseName { get; set; }

   public required DateTime StartingDate{get;set;} = DateTime.UtcNow;
   
   [Required]
   public required DateTime EndDate { get; set; }

   public ICollection<CourseSubject> CourseSubject { get; set; }=[];
   public ICollection<StudentCourse> StudentCourse { get; set; }=[];

}