using Microsoft.EntityFrameworkCore;
using ShubraRanjanAPI.Entities;
using ShubraRanjanAPI.Entities.AssociationTable;

public class EnrollRepository(AppDbContext context) : IEnrollRepository
{
   public async Task<bool> EnrolStudent(string userId,int courseId)
   {

      var profile = await GetStudentProfile(userId);
      if(profile!=null){
         var existingEnrollment = await context.StudentCourses.FirstOrDefaultAsync(sc=>sc.StudentCourseId==profile.StudentId&&
                                                                                 sc.CourseId ==courseId);
         if (existingEnrollment != null)
         {
            return false;
         }
         var enrollment = new StudentCourse
         {
            StudentProfileId = profile.StudentId,
            CourseId = courseId
         };
         context.StudentCourses.Add(enrollment);
         var result = await context.SaveChangesAsync();
         return result>0;
      }
      return false;
   }

   public async Task<IList<CourseDto>> GetAllCourse(string userId)
   {
      var profile = await GetStudentProfile(userId);
      var allCourses = await context.StudentCourses.Where(sc=>sc.StudentProfileId == profile.StudentId)
                                                   .Select(sc=> new CourseDto
                                                   {
                                                      CourseId = sc.CourseId,
                                                      CourseName = sc.Course.CourseName,
                                                      StartingDate = sc.Course.StartingDate,
                                                      EndDate = sc.Course.EndDate
                                                   }).ToListAsync();
      if (allCourses != null)
      {
         return allCourses;
      }
      return null!;
   }

   public async Task<bool> LeaveCourse(string userId,int courseId)
   {
      var profile = await GetStudentProfile(userId);
      if (profile != null)
      {
         var enrollment = await context.StudentCourses
                .FirstOrDefaultAsync(sc => sc.StudentProfileId == profile.StudentId && sc.CourseId == courseId);

            if (enrollment == null)
            {
               return false;
            }
         context.StudentCourses.Remove(enrollment);
         var result = await context.SaveChangesAsync();
         return result>0;
      }
      return false;
   }

   public async Task<StudentProfile?> GetStudentProfile(string userId)
   {
      return await context.StudentProfiles.FirstOrDefaultAsync(sp => sp.UserId == userId);
   }
}