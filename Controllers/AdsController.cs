using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Misty.Commands;
using Misty.Commands.Ads;

namespace Misty.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAd(CreateNewAd command)
            => Created("", await _mediator.Send(command));

        [HttpPut("{adId:int}")]
        public async Task<IActionResult> UpdateAd(UpdateAd command)
            => Ok(await _mediator.Send(command));

        [HttpGet("{adId:int}")]
        public async Task<IActionResult> GetAd(int adId)
            => Ok();

        [HttpGet]
        public async Task<IActionResult> GetAds()
            => Ok();
    }
}