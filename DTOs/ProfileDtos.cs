using ShubraRanjanAPI.Entities.AssociationTable;

namespace ShubraRanjanAPI.DTOs
{
    public class StudentProfileDto
    {
         public int StudentId { get; set; }
         public DateTime EnrolementDate { get; set; }
         public List<int>? EnrolledCourseIds { get; set; }
    }

    public class TeacherProfileDto
    {
        public int TeacherId { get; set; }
        public string? Bio { get; set; }
        public DateTime HireDate { get; set; }
        public int? SubjectId { get; set; }

    }
}