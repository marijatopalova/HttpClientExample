using HttpClientExample.Models;

namespace HttpClientExample.Services
{
    public class TypedApiService(HttpClient httpClient)
    {
        public async Task<IEnumerable<Post>?> GetPostsAsync()
        {
            IEnumerable<Post>? posts = await httpClient
                .GetFromJsonAsync<IEnumerable<Post>>("posts");

            return posts;
        }
    }
}
