using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Misty.Domain.Entities.Users;
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
        public async Task<IActionResult> Get()
        {
            var creator = new Moderator("un", "pw", "dd", "::1");
            await _context.Users.AddAsync(creator);
            await _context.SaveChangesAsync();
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }
    }
}