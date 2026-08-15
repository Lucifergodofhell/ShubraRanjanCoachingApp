using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class IdentityRolesConfigurations : IEntityTypeConfiguration<IdentityRole>
{
   public void Configure(EntityTypeBuilder<IdentityRole> builder)
   {
      builder.HasData(
         new IdentityRole
         {
            Id="1",
            Name="Admin",
            NormalizedName="ADMIN"
         },
         new IdentityRole
         {
            Id="2",
            Name="Student",
            NormalizedName="STUDENT"
         },
         new IdentityRole
         {
            Id="3",
            Name="Teacher",
            NormalizedName="TEACHER"
         }
      );
   }
}