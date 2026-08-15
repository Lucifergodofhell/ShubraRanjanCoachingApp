using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShubraRanjanAPI.Entities;



[Authorize(Policy = "RequireAdminRole")]
public class CourseController(ICourseServices courseServices) : BaseController
{

   [HttpGet]
   public async Task<ActionResult<List<CourseDto>>> GetAllCourse()
   {
      var result = await courseServices.GetAllCourse();
      if (result != null)
      {
         var resultDto = result.Select(c=>c.ToDto()).ToList();
         return resultDto;
      }
      return BadRequest("Error while getting all course list");
   }

   [HttpPost("create-course")]
   public async Task<ActionResult> CreateCourse(CourseDto courseDto)
   {
      var result = await courseServices.CreateCourse(courseDto);
      if (result)
      {
         return Created();
      }
      return BadRequest("Error while creating course");
   }
   [HttpGet("{courseId}")]
   public async Task<ActionResult<CourseDto>> GetCourse(int courseId)
   {
      var result = await courseServices.GetCourse(courseId);
      if (result != null)
      {
         return result.ToDto();
      }
      return NotFound("Error while geting course"); 
   }

   [HttpDelete("delete-course/{courseId}")]
   public async Task<ActionResult> DeleteCourse(int courseId)
   {
      var result = await courseServices.DeleteCourse(courseId);
      if (result)
      {
         return Ok("Course has been Deleted");
      }
      return BadRequest("Error while deleting course");
   }
   [HttpPut("update")]
   public async Task<ActionResult> ModifySubject(CourseDto courseDto)
   {
      var result = await courseServices.ModifyCourse(courseDto);
      if (result)
      {
         return Ok("Course has been Modified");
      }
      return BadRequest("Error while modifying course");
   }
}