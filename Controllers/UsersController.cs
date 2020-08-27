using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Misty.Commands.Users;

namespace Misty.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateNewUser command)
            => Created("", await _mediator.Send(command));

        [HttpPost]
        public async Task<IActionResult> Login(LoginUser command)
            => Ok(await _mediator.Send(command));
    }
}