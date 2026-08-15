
using ShubraRanjanAPI.Entities.AssociationTable;

namespace ShubraRanjanAPI.Entities;
public class Content
{
    public int Id { get; set; }
    public int CourseSubjectId { get; set; } 
    public string ContentName { get; set; }
    public string ContentUrl { get; set; }
    public ContentType Type { get; set; } 

    // Navigation Property
    public CourseSubject CourseSubject { get; set; }
}

// Enum for easy content type management
public enum ContentType
{
    PDF = 1,
    Video = 2
}