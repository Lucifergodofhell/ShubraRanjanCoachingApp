
using ShubraRanjanAPI.Entities;

public static class  CourseExtension
{
   public static CourseDto ToDto(this Course course)
   {
      return new CourseDto
      {
         CourseId = course.CourseId,
         CourseName = course.CourseName,
         StartingDate = course.StartingDate,
         EndDate = course.EndDate
      };
   }
}