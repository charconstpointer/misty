using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Misty.Domain.Entities;
using Misty.Persistence;

namespace Misty.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RunnerController : ControllerBase
    {
        private readonly MistyContext _context;

        public RunnerController(MistyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Run()
        {
            var article = Article.Create("title", "desc");
            var comment = new Comment("comment");
            article.AddComment(comment);
            await _context.Articles.AddAsync(article);
            await _context.SaveChangesAsync();
            var q = await _context.Articles.FirstOrDefaultAsync();
            return Ok(q);
        }
    }
}