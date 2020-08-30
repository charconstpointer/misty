using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Misty.Commands.Categories;
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
            => Created("", await _mediator.Send(command));

        [HttpDelete("{categoryId:int}")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
            => NoContent();

        [HttpPut("{categoryId:int}")]
        public async Task<IActionResult> UpdateCategory(int categoryId)
            => NoContent();

        [HttpGet]
        public async Task<IActionResult> GetCategories()
            => Ok(await _mediator.Send(new GetCategories()));
    }
}