using BikeRental.StationService.Controllers.Commands;
using BikeRental.StationService.Controllers.Queries;
using BikeRental.StationService.Responses;
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

        [HttpPost("{stationId}/bike")]
        public async Task<ActionResult> AddBike(int stationId, [FromBody] AddBikeToStationCommand command)
        {
            try
            {
                command.StationId = stationId;
                await _mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }

        [HttpDelete("{stationId}/bike")]
        public async Task<ActionResult> RemoveBike(int stationId, [FromBody] RemoveBikeToStationCommand command)
        {
            try
            {
                command.StationId = stationId;
                await _mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StationResponse>>> GetAll()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllStationsQuery()));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }
    }
}
