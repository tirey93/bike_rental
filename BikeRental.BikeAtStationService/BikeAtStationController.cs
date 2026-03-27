using BikeRental.BikeAtStationService.Application.CommandHandlers;
using BikeRental.BikeAtStationService.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BikeRental.BikeAtStationService
{
    [ApiController]
    [Route("[controller]")]
    public class BikeAtStationController : ControllerBase
    {
        private readonly ILogger<BikeAtStationController> _logger;
        private readonly IMediator _mediator;

        public BikeAtStationController(ILogger<BikeAtStationController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] AddBikeToStationCommand command)
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

        [HttpDelete]
        public async Task<ActionResult> Remove([FromBody] RemoveBikeFromStationCommand command)
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
