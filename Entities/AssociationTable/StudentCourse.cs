
namespace ShubraRanjanAPI.Entities.AssociationTable;
public class StudentCourse
{
   public int StudentCourseId { get; set; }
   public int StudentProfileId { get; set; }
   public int CourseId { get; set; }

   //Defining Navigational Property
   public Course  Course { get; set; }
   public StudentProfile StudentProfile { get; set; }
}