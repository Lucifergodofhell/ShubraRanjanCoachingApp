using System.Linq.Expressions;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using ShubraRanjanAPI.Entities;
using ShubraRanjanAPI.Interface.RepositoryInterface;
using ShubraRanjanAPI.Interface.ServiceInterface;
using ShubraRanjanAPI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddScoped<IAccountRepositories, AccountRepositories>();
builder.Services.AddScoped<IAccountServices, AccountServices>();
builder.Services.AddScoped<ITokenServices, TokenServices>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<ISubjectServices, SubjectServices>();
builder.Services.AddScoped<ITeacherServices, TeacherService>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<ICourseServices, CourseServices>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Enter your JWT token formatted as: Bearer {your_token}",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new List<string>()
        }
    });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
   options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddIdentityCore<AppUser>(options =>
{
   options.Password.RequiredLength = 6;
   options.Password.RequireLowercase=true;
   options.Password.RequireUppercase = true;
}).AddRoles<IdentityRole>()
.AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
   var tokenKey = builder.Configuration["TokenKey"]?? throw new Exception("token key not found - Program.cs");
   options.TokenValidationParameters = new TokenValidationParameters
   {
      ValidateIssuerSigningKey = true,
      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey)),
      ValidateIssuer = false,
      ValidateAudience = false,
   };
});
builder.Services.AddAuthorizationBuilder()
               .AddPolicy("RequireAdminRole",policy =>policy.RequireRole("Admin"))
               .AddPolicy("ModerateCoachingRoles",policy=>policy.RequireRole("Admin","Teacher"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
using(var scope = app.Services.CreateScope())
{
   var services = scope.ServiceProvider;
   try
   {
      await SeedData.InitializeData(services);
   }catch(Exception ex)
   {
      var logger = services.GetRequiredService<ILogger<Program>>();
      logger.LogError(ex,"Error occured while seeding data to database");
   }
}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("ReactAppCORS");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
