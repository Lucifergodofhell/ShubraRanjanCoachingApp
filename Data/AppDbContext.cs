using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShubraRanjanAPI.Entities;
using ShubraRanjanAPI.Entities.AssociationTable;

public class AppDbContext:IdentityDbContext<AppUser>
{
   public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions)
                                                         : base(dbContextOptions)
   {
      
   }
   public DbSet<Course> Courses { get; set; }
   public DbSet<Subject>  Subjects { get; set; }
   public DbSet<StudentProfile> StudentProfiles{get;set;}
   public DbSet<TeacherProfile> TeacherProfiles{get;set ;}
   public DbSet<Content> Contents{get;set;}
   public DbSet<CourseSubject> CourseSubjects{get;set;}
   public DbSet<StudentCourse> StudentCourses{get;set;}

   protected override void OnModelCreating(ModelBuilder builder)
   {
      base.OnModelCreating(builder);
      builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
   }

}