using HttpClientExample.Models;
using Refit;

namespace HttpClientExample.Services
{
    public interface IJsonPlaceholderApi
    {
        [Get("/posts")]
        public Task<IEnumerable<Post>> GetPostsAsync();
    }
}
