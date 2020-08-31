using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Misty.Commands.Ads;
using Misty.Queries.Ads;

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
        {
            return Created("", await _mediator.Send(command));
        }

        [HttpPut("{adId:int}")]
        public async Task<IActionResult> UpdateAd(UpdateAd command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("{adId:int}")]
        public async Task<IActionResult> GetAd(int adId)
        {
            var q = new GetAd {AdId = adId};
            return Ok(await _mediator.Send(q));
        }

        [HttpGet]
        public async Task<IActionResult> GetAds()
        {
            return Ok(await _mediator.Send(new GetAds()));
        }
    }
}