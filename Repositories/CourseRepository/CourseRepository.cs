using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShubraRanjanAPI.Entities;

public class CourseRepository(AppDbContext context) : ICourseRepository
{
   public async Task<bool> CreateCourse(CourseDto courseDto)
   {
      Course course  = new Course
      {
        CourseName = courseDto.CourseName,
        StartingDate = DateTime.UtcNow,
        EndDate = DateTime.UtcNow.AddYears(1)
      };
      await context.Courses.AddAsync(course);
      var saved = await context.SaveChangesAsync();
      return saved>0;
   }

   public async  Task<bool> DeleteCourse(int courseId)
   {
      var result = await context.Courses.Where(s=>s.CourseId==courseId).ExecuteDeleteAsync();
      return result>0;
   }

   public async Task<IList<Course>> GetAllCourse()
   {
      return await context.Courses.ToListAsync();
   }

   public async Task<Course?> GetCourse(int courseId)
   {
      return  await context.Courses.FirstOrDefaultAsync(s=>s.CourseId==courseId);
   }

   public async Task<bool> ModifyCourse(CourseDto courseDto)
   {
      var result = await context.Courses.Where(s=>s.CourseId==courseDto.CourseId)
                                       .ExecuteUpdateAsync(s=> s.SetProperty(u=>u.CourseName,courseDto.CourseName)
                                                               .SetProperty(u=>u.StartingDate,courseDto.StartingDate)
                                                               .SetProperty(u=>u.EndDate,courseDto.EndDate));
      return result>0;
   }
}