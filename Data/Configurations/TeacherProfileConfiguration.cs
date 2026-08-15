


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShubraRanjanAPI.Entities;

public class TeacherProfileConfiguration : IEntityTypeConfiguration<TeacherProfile>
{
   public void Configure(EntityTypeBuilder<TeacherProfile> builder)
   {
      builder.HasKey(t=>t.TeacherId);

      builder.Property(s=>s.TeacherId).ValueGeneratedOnAdd();

      builder.HasOne(t=>t.Subject)
            .WithMany(s=>s.TeacherProfiles)
            .HasForeignKey(t=>t.SubjectId)
            .OnDelete(DeleteBehavior.SetNull);
   
      builder.HasOne(u=>u.AppUser)
            .WithOne(t=>t.TeacherProfile)
            .HasForeignKey<TeacherProfile>(t=>t.UserId)
            .OnDelete(DeleteBehavior.Cascade);

      
   }
}