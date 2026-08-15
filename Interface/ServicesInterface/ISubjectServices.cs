using Microsoft.AspNetCore.Identity;
using ShubraRanjanAPI.Entities;

public interface ISubjectServices
{
   Task<bool> CreateSubject(SubjectDto subjectDto);
   Task<bool> ModifySubject(SubjectDto subjectDto);
   Task<bool> DeleteSubject(int subjectId);
   Task<Subject> GetSubject(int subjectId);
   Task<IList<Subject>>GetAllSubject();
}