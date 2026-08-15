using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShubraRanjanAPI.Entities;



[Authorize(Policy = "RequireAdminRole")]
public class SubjectController(ISubjectServices subjectServices) : BaseController
{

   [HttpGet]
   public async Task<ActionResult<List<SubjectDto>>> GetAllSubject()
   {
      var result = await subjectServices.GetAllSubject();
      if (result != null)
      {
         var resultDto = result.Select(c=>c.ToDto()).ToList();
         return resultDto;
      }
      return BadRequest("Error while getting all subject list");
   }
   [HttpPost("create-Subject")]
   public async Task<ActionResult> CreateSubject(SubjectDto subjectDto)
   {
      var result = await subjectServices.CreateSubject(subjectDto);
      if (result)
      {
         return Created();
      }
      return BadRequest("Error while creating subject");
   }
   [HttpGet("{subjectId}")]
   public async Task<ActionResult<SubjectDto>> GetSubject(int subjectId)
   {
      var result = await subjectServices.GetSubject(subjectId);
      if (result != null)
      {
         return result.ToDto();
      }
      return NotFound("Error while geting subject"); 
   }

   [HttpDelete("delete-subject/{subjectId}")]
   public async Task<ActionResult> DeleteSubject(int subjectId)
   {
      var result = await subjectServices.DeleteSubject(subjectId);
      if (result)
      {
         return Ok("Subject has been Deleted");
      }
      return BadRequest("Error while deleting subject");
   }
   [HttpPut("update")]
   public async Task<ActionResult> ModifySubject(SubjectDto subjectDto)
   {
      var result = await subjectServices.ModifySubject(subjectDto);
      if (result)
      {
         return Ok("Subject has been Modified");
      }
      return BadRequest("Error while modifying subject");
   }
}