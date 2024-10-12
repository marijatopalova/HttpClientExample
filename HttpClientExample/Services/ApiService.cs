using HttpClientExample.Models;
using System.Text.Json;

namespace HttpClientExample.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Post>> GetDataAsync()
        {
            var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStreamAsync();

                return await JsonSerializer.DeserializeAsync<IEnumerable<Post>>(content);
            }

            return null;
        }
    }
}
