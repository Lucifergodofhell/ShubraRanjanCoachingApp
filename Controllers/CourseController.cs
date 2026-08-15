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

   [HttpPost("add-subject")]
   public async Task<ActionResult> AddSubToCourse(SubCourseDto subCourseDto)
   {
      var result = await courseServices.AddSubToCourse(subCourseDto);
      if (result)
      {
         return Ok("Subject has been added to course");
      }
      return BadRequest("Error while adding subject to course");
   }
   [HttpGet("gets-subject/{courseId}")]
   public async Task<ActionResult<IList<SubjectDto>>> GetSubToCourse(int courseId)
   {
      var result = await courseServices.GetSubToCourse(courseId);
      if (result!=null)
      {
         return Ok(result);
      }
      return BadRequest("Error while getting subject for course");
   }

   [HttpDelete("delete-subject")]
   public async Task<ActionResult> DeleteSubFromCourse(SubCourseDto subCourseDto)
   {
      var result = await courseServices.DeleteSubFromCourse(subCourseDto);
      if (result)
      {
         return Ok("Subject has been delted from course");
      }
      return BadRequest("Error while deleting subject from course");
   }
}