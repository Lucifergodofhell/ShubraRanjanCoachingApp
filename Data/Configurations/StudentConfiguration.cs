

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShubraRanjanAPI.Entities;

public class StudentConfiguration : IEntityTypeConfiguration<StudentProfile>
{
   public void Configure(EntityTypeBuilder<StudentProfile> builder)
   {
      builder.HasKey(s=>s.StudentId);

      builder.Property(s=>s.StudentId).ValueGeneratedOnAdd();

      builder.HasOne(s=>s.AppUser)
               .WithOne(s=>s.StudentProfile)
               .HasForeignKey<StudentProfile>(s=>s.UserId)
               .OnDelete(DeleteBehavior.Cascade);

      builder.HasMany(x=>x.StudentCourses)
            .WithOne(x=>x.StudentProfile)
            .OnDelete(DeleteBehavior.Cascade);
         

   }
}