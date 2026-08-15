
using ShubraRanjanAPI.Entities.AssociationTable;

public  interface IEnrollServices
{
   Task<bool> EnrolStudent(string userId,int courseId);
   Task<IList<CourseDto>> GetAllCourse(string userId);
   Task<bool> LeaveCourse(string userId,int courseId);

}