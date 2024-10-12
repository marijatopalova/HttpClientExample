using HttpClientExample.Models;
using HttpClientExample.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HttpClientExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController(ApiService apiService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetAllPosts()
        {
            var result = await apiService.GetDataAsync();

            return Ok(result);
        }
    }
}
