


public class CourseDto
{
   public int? CourseId { get; set; }
   public required string CourseName { get; set; }
   public required DateTime StartingDate{get;set;} = DateTime.UtcNow;
   public required DateTime EndDate { get; set; }
}