using ShubraRanjanAPI.Entities;
using ShubraRanjanAPI.DTOs;

public static class ProfileExtensions
{
    public static StudentProfileDto ToDto(this StudentProfile profile)
    {
      return new StudentProfileDto
      {
         StudentId = profile.StudentId,
         EnrolementDate = profile.EnrolementDate,
         EnrolledCourseIds = profile.StudentCourses?.Select(sc => sc.CourseId).ToList()
      };
   }

   public static TeacherProfileDto ToDto(this TeacherProfile profile)
   {
      return new TeacherProfileDto
      {
         TeacherId = profile.TeacherId,
         Bio = profile.Bio,
         SubjectId = profile.SubjectId
      };
   }
}
