

using ShubraRanjanAPI.Entities;
using ShubraRanjanAPI.Entities.AssociationTable;

public class EnrollServices(IEnrollRepository enrollRepository) : IEnrollServices
{
   public async Task<bool> EnrolStudent(string userId,int courseId)
   {
      return await enrollRepository.EnrolStudent(userId,courseId);
   }

   public async Task<IList<CourseDto>> GetAllCourse(string userId)
   {
     return await enrollRepository.GetAllCourse(userId);
   }

   public async Task<bool> LeaveCourse(string userId,int courseId)
   {
       return await enrollRepository.LeaveCourse(userId,courseId);
   }
}