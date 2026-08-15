using System.Text.Json.Serialization;


namespace ShubraRanjanAPI.Entities.AssociationTable;
public class CourseSubject
{
   public int CourseSubjectId { get; set; }
   public int CourseId { get; set; }
   public int SubjectId { get; set; }

   //Defining Navigational Property
   public Course  Course { get; set; }
   public Subject Subject { get; set; }

   public ICollection<Content> Contents { get; set; } = new List<Content>();
}