using ShubraRanjanAPI.Entities;

public class CourseServices(ICourseRepository courseRepository) : ICourseServices
{
   public async Task<bool> CreateCourse(CourseDto courseDto )
   {
      return await courseRepository.CreateCourse(courseDto);
   }

   public async  Task<bool> DeleteCourse(int courseId)
   {
     return await courseRepository.DeleteCourse(courseId);
   }

   public async Task<IList<Course>> GetAllCourse()
   {
      return await courseRepository.GetAllCourse();
   }

   public async Task<Course> GetCourse(int courseId)
   {
      return await courseRepository.GetCourse(courseId);
   }

   public async Task<bool> ModifyCourse(CourseDto courseDto)
   {
      return await courseRepository.ModifyCourse(courseDto);
   }
}