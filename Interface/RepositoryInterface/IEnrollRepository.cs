using ShubraRanjanAPI.Entities.AssociationTable;

public interface IEnrollRepository
{
    Task<bool> EnrolStudent(string userId,int courseId);
   Task<IList<CourseDto>> GetAllCourse(string userId);
   Task<bool> LeaveCourse(string userId,int courseId);
}