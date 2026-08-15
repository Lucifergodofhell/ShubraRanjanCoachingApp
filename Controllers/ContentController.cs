
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShubraRanjanAPI.Interface.ServiceInterface;


[Authorize(Policy ="ModerateCoachingRoles")]
public class ContentController(IContentServices contentServices) : BaseController
{
   [HttpPost("upload")]
   public async Task<IActionResult> UploadContent([FromForm] int courseId, 
                                             [FromForm] string subject, IFormFile file)
   {
      if (file == null || file.Length == 0)
      {
         return BadRequest("Please provide a valid file.");
      }
      var result = await contentServices.UploadContentAsync(courseId, subject, file);
      if (!result)
      {
         return BadRequest("Failed to upload content to Cloudinary or save to DB.");
      }
      return Ok(new { Message = "Content uploaded and saved successfully!" });
   }
   [HttpDelete("delete/{contentId}")]
   public async Task<IActionResult> DeleteContent(int contentId)
   {
      var result = await contentServices.DeleteContentAsync(contentId);
      if (!result)
      {
         return BadRequest("Failed to delete content. Please check the content ID.");
      }
      return Ok(new { Message = "Content deleted successfully!" });
   }
}