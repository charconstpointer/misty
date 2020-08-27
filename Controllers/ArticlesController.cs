using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Misty.Commands;
using Misty.Commands.Comments;
using Misty.Queries;

namespace Misty.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArticlesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateArticle(CreateNewArticle command)
        {
            return Created("", await _mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetArticles()
        {
            return Ok(await _mediator.Send(new GetArticles()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetArticle(int id)
        {
            return Ok(await _mediator.Send(new GetArticle {ArticleId = id}));
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            return Ok(await _mediator.Send(new DeleteArticle {ArticleId = id}));
        }

        [HttpPost("{articleId:int}/comments")]
        [Authorize]
        public async Task<IActionResult> CreateComment(int articleId, CreateComment command)
        {
            command.ArticleId = articleId;
            return Created("", await _mediator.Send(command));
        }

        [HttpGet("{articleId:int}/comments")]
        public async Task<IActionResult> GetComments(int articleId)
        {
            return Ok(await _mediator.Send(new GetArticleComments {ArticleId = articleId}));
        }
    }
}