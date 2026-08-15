
using ShubraRanjanAPI.Entities;

public static class  SubjectExtension
{
   public static SubjectDto ToDto(this Subject subject)
   {
      return new SubjectDto
      {
         SubjectId = subject.SubjectId,
         SubjectName=subject.SubjectName
      };
   }
}