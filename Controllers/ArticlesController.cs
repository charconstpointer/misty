using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Misty.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticlesController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateArticle() => Ok();
        [HttpGet]
        public async Task<IActionResult> GetArticles() => Ok();
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetArticle(int id) => Ok();
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteArticle(int id) => Ok();
    }
}