using Microsoft.EntityFrameworkCore;
using ShubraRanjanAPI.Entities;
using ShubraRanjanAPI.Interface.RepositoryInterface;

namespace ShubraRanjanAPI.Repositories
{
    public class ContentRepository(AppDbContext context) : IContentRepository
    {
        public async Task<bool> AddContentAsync(int courseSubjectId, string contentName, string contentUrl, int type)
        {
            var newContent = new Content
            {
                CourseSubjectId = courseSubjectId,
                ContentName = contentName,
                ContentUrl = contentUrl,
                Type = ContentType.PDF
            };

            context.Contents.Add(newContent);
            var result = await context.SaveChangesAsync();
            
            return result > 0;
        }

        public async Task<Content?> GetContentByIdAsync(int id)
        {
            return await context.Contents.FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<bool> RemoveContentAsync(int id)
        {
            var content = await context.Contents.FirstOrDefaultAsync(c => c.Id == id);
            
            if (content == null)
            {
                return false;
            }

            context.Contents.Remove(content);
            var result = await context.SaveChangesAsync();
            
            return result > 0;
        }
    }
}