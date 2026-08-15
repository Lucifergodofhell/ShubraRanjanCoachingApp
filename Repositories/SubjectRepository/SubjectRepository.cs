using System.ComponentModel.Design.Serialization;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShubraRanjanAPI.Entities;

public class SubjectRepository(AppDbContext context) : ISubjectRepository
{
   public async Task<bool> CreateSubject(SubjectDto subjectDto)
   {
      Subject subject  = new Subject
      {
        SubjectName = subjectDto.SubjectName 
      };
      await context.Subjects.AddAsync(subject);
      var saved = await context.SaveChangesAsync();
      return saved>0;
   }

   public async  Task<bool> DeleteSubject(int subjectId)
   {
      var result = await context.Subjects.Where(s=>s.SubjectId==subjectId).ExecuteDeleteAsync();
      return result>0;
   }

   public async Task<IList<Subject>> GetAllSubject()
   {
      return await context.Subjects.ToListAsync();
   }

   public async Task<Subject?> GetSubject(int SubjectId)
   {
      return  await context.Subjects.FirstOrDefaultAsync(s=>s.SubjectId==SubjectId);
   }

   public async Task<bool> ModifySubject(SubjectDto subjectDto)
   {
      var result = await context.Subjects.Where(s=>s.SubjectId==subjectDto.SubjectId)
                                       .ExecuteUpdateAsync(s=> s.SetProperty(u=>u.SubjectName,subjectDto.SubjectName));
      return result>0;
   }
}