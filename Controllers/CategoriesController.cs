using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Misty.Commands.Categories;
using Misty.Queries.Articles;
using Misty.Queries.Categories;

namespace Misty.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateNewCategory command)
        {
            return Created("", await _mediator.Send(command));
        }

        [HttpDelete("{categoryId:int}")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            return Ok(await _mediator.Send(new DeleteCategory {CategoryId = categoryId}));
        }

        [HttpPut("{categoryId:int}")]
        public async Task<IActionResult> UpdateCategory(int categoryId)
        {
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var cats = await _mediator.Send(new GetCategories());
            return Ok(cats);
        }

        [HttpGet("{categoryId:int}/articles")]
        public async Task<IActionResult> GetArticles(int categoryId)
        {
            return Ok(await _mediator.Send(new GetArticlesByCategory(categoryId)));
        }
    }
}