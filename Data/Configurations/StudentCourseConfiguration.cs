
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShubraRanjanAPI.Entities.AssociationTable;

public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
{
   public void Configure(EntityTypeBuilder<StudentCourse> builder)
   {
      builder.HasKey(sc=>sc.StudentCourseId);

      builder.Property(sc=>sc.StudentCourseId).ValueGeneratedOnAdd();

      builder.HasOne(s=>s.StudentProfile)
            .WithMany(c=>c.StudentCourses)
            .HasForeignKey(sc=>sc.StudentProfileId)
            .OnDelete(DeleteBehavior.Cascade);
      
      builder.HasOne(c=>c.Course)
            .WithMany(s=>s.StudentCourse)
            .HasForeignKey(sc=>sc.CourseId)
            .OnDelete(DeleteBehavior.Cascade);
   

   }
}