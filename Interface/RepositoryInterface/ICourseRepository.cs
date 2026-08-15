using Microsoft.AspNetCore.Identity;
using ShubraRanjanAPI.Entities;

public interface ICourseRepository
{
   Task<bool> CreateCourse(CourseDto courseDto);
   Task<bool> ModifyCourse(CourseDto courseDto);
   Task<bool> DeleteCourse(int courseId);
   Task<Course> GetCourse(int courseId);
   Task<IList<Course>> GetAllCourse();
   Task<bool> AddSubToCourse(SubCourseDto subCourseDto);
   Task<IList<SubjectDto>> GetSubToCourse(int courseId);
   Task<bool> DeleteSubFromCourse(SubCourseDto subCourseDto);

}