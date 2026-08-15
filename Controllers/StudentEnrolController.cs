using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

[Authorize(Roles = "Student")]
public class StudentEnrolController(IEnrollServices enrollServices) : BaseController
{
   
   [HttpPost("{courseId}")]
   public async Task<ActionResult> EnrolStudent(int courseId)
   {
      string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (userId == null)
      {
         return Unauthorized("Please login/signup First than you can enroll");
      }
      var result = await enrollServices.EnrolStudent(userId,courseId);
      if (!result)
      {
         return BadRequest("Error while enrolling please retry");
      }
      return Ok("You have been enrolled Sucessfully");
   }

   [HttpGet("student-course")]
   public async Task<ActionResult<IList<CourseDto>>> GetAllCourse()
   {
      string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (userId == null)
      {
         return Unauthorized("Please login/signup first");
      }
      var result = await enrollServices.GetAllCourse(userId);
      if (result==null)
      {
         return BadRequest("Error while getting courses");
      }
      return Ok(result);
   }

   [HttpDelete("leave-course/{courseId}")]
   public async Task<ActionResult> LeaveCourse(int courseId)
   {
      string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (userId == null)
      {
         return Unauthorized("Please login/signup First than you can enroll");
      }
      var result = await enrollServices.LeaveCourse(userId,courseId);
      if (!result)
      {
         return BadRequest("Error while leaving course please retry");
      }
      return Ok("You have left Course Sucessfully");
   }
}
