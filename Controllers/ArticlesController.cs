using System.Threading.Tasks;
using MediatR;
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
        public async Task<IActionResult> CreateArticle(CreateNewArticle command)
            => Created("", await _mediator.Send(command));

        [HttpGet]
        public async Task<IActionResult> GetArticles()
            => Ok(await _mediator.Send(new GetArticles()));

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetArticle(int id)
            => Ok(await _mediator.Send(new GetArticle {ArticleId = id}));

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteArticle(int id)
            => Ok(await _mediator.Send(new DeleteArticle {ArticleId = id}));

        [HttpPost("{id:int}/comments")]
        public async Task<IActionResult> CreateComment(int articleId, CreateComment command)
            => Created("", await _mediator.Send(command));
        
        [HttpGet("{id:int}/comments")]
        public async Task<IActionResult> GetComments(int articleId)
            => Ok(await _mediator.Send(new GetArticleComments{ArticleId = articleId}));
    }
}