using HttpClientExample.Models;
using System.Text.Json;

namespace HttpClientExample.Services
{
    public class PostsService(IHttpClientFactory httpClientFactory) : IPostsService
    {
        #region HttpClient Basic Usage

        //public async Task<IEnumerable<Post>?> GetPostsAsync()
        //{
        //    using var client = new HttpClient();

        //    client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");

        //    IEnumerable<Post>? posts = await client.
        //        GetFromJsonAsync<IEnumerable<Post>>("posts");

        //    return posts;
        //}

        #endregion

        #region Named Client

        public async Task<IEnumerable<Post>?> GetPostsAsync()
        {
            var client = httpClientFactory.CreateClient("JsonPlaceholderClient");

            IEnumerable<Post>? posts = await client
                .GetFromJsonAsync<IEnumerable<Post>>("posts");

            return posts;
        }

        #endregion
    }
}
