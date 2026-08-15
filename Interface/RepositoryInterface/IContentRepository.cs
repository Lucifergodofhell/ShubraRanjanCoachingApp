using ShubraRanjanAPI.Entities; 

namespace ShubraRanjanAPI.Interface.RepositoryInterface
{
    public interface IContentRepository
    {
        Task<bool> AddContentAsync(int courseSubjectId, string contentName, string contentUrl, int type);
        Task<Content?> GetContentByIdAsync(int id);
        Task<bool> RemoveContentAsync(int id);
    }
}