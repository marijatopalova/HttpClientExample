using HttpClientExample.Models;

namespace HttpClientExample.Services
{
    public interface IPostsService
    {
        Task<IEnumerable<Post>> GetPostsAsync();
    }
}
