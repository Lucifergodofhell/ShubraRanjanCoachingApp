using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShubraRanjanAPI.Entities.AssociationTable;

public class CourseSubjectConfiguration : IEntityTypeConfiguration<CourseSubject>
{
   public void Configure(EntityTypeBuilder<CourseSubject> builder)
   {
      builder.HasKey(cs=>cs.CourseSubjectId);

      builder.Property(cs=>cs.CourseSubjectId).ValueGeneratedOnAdd();

      builder.HasOne(cs=>cs.Course)
            .WithMany(s=>s.CourseSubject)
            .HasForeignKey(c=>c.CourseId)
            .OnDelete(DeleteBehavior.Cascade);
      
      builder.HasOne(cs=>cs.Subject)
            .WithMany(s=>s.CourseSubjects)
            .HasForeignKey(s=>s.SubjectId)
            .OnDelete(DeleteBehavior.Cascade);

   }
}