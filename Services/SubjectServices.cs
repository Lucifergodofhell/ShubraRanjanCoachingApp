using ShubraRanjanAPI.Entities;

public class SubjectServices(ISubjectRepository subjectRepository) : ISubjectServices
{
   public async Task<bool> CreateSubject(SubjectDto subjectDto)
   {
      return await subjectRepository.CreateSubject(subjectDto);
   }

   public async  Task<bool> DeleteSubject(int subjectId)
   {
     return await subjectRepository.DeleteSubject(subjectId);
   }

   public async Task<IList<Subject>> GetAllSubject()
   {
      return await subjectRepository.GetAllSubject();
   }

   public async Task<Subject> GetSubject(int subjectId)
   {
      return await subjectRepository.GetSubject(subjectId);
   }

   public async Task<bool> ModifySubject(SubjectDto subjectDto)
   {
      return await subjectRepository.ModifySubject(subjectDto);
   }
}