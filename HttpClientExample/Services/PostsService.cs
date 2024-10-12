using HttpClientExample.Models;
using System.Text.Json;

namespace HttpClientExample.Services
{
    public class PostsService(HttpClient httpClient) : IPostsService
    {
        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            var posts = await httpClient.GetFromJsonAsync<IEnumerable<Post>>("https://jsonplaceholder.typicode.com/posts");

            return posts;
        }
    }
}
