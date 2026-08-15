using Microsoft.AspNetCore.Http;

namespace ShubraRanjanAPI.Interface.ServiceInterface
{
    public interface IContentServices
    {
        Task<bool> UploadContentAsync(int courseId, string subject, IFormFile file);
        Task<bool> DeleteContentAsync(int contentId);
    }
}