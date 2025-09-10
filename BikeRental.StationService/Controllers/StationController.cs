using BikeRental.StationService.Controllers.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BikeRental.StationService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StationController : ControllerBase
    {
        private readonly ILogger<StationController> _logger;

        private readonly IMediator _mediator;

        public StationController(ILogger<StationController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateStationCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }
    }
}
