using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ShubraRanjanAPI.Interface.RepositoryInterface;
using ShubraRanjanAPI.Interface.ServiceInterface;

namespace ShubraRanjanAPI.Services
{
    public class ContentServices(IConfiguration config, IContentRepository contentRepository) : IContentServices
    {
        private readonly Cloudinary _cloudinary = new Cloudinary(new Account(
            config["Cloudinary:CloudName"],
            config["Cloudinary:ApiKey"],
            config["Cloudinary:ApiSecret"]
        ));

        public async Task<bool> UploadContentAsync(int courseSubjectId, string subjectName, IFormFile file)
        {
            var originalFileName = Path.GetFileNameWithoutExtension(file.FileName);
            var contentName = $"{subjectName}-{originalFileName}".Replace(" ", "-").ToLower();

            using var stream = file.OpenReadStream();
            UploadResult uploadResult;
            int contentTypeEnum = 0; 

            if (file.ContentType.Contains("video"))
            {
                contentTypeEnum = 1;
                var videoParams = new VideoUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    PublicId = contentName 
                };
                uploadResult = await _cloudinary.UploadAsync(videoParams);
            }
            else
            {
                contentTypeEnum = 0; 
                var rawParams = new RawUploadParams 
                {
                    File = new FileDescription(file.FileName, stream),
                    PublicId = contentName
                };
                uploadResult = await _cloudinary.UploadAsync(rawParams);
            }

            if (uploadResult.Error != null) return false;

            return await contentRepository.AddContentAsync(
                courseSubjectId, 
                contentName, 
                uploadResult.SecureUrl.ToString(), 
                contentTypeEnum
            );
        }

        public async Task<bool> DeleteContentAsync(int id)
        {
            var content = await contentRepository.GetContentByIdAsync(id);
            if (content == null) return false;
            var resourceType = (int)content.Type == 1 ? ResourceType.Video : ResourceType.Raw;
            var delParams = new DeletionParams(content.ContentName)
            {
                ResourceType = resourceType
            };
            
            var deletionResult = await _cloudinary.DestroyAsync(delParams);
            if (deletionResult.Result == "ok" || deletionResult.Result == "not found")
            {
                return await contentRepository.RemoveContentAsync(id);
            }

            return false;
        }
    }
}