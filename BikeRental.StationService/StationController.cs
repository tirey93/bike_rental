using BikeRental.StationService.Application.CommandHandlers.Station;
using BikeRental.StationService.Application.QueryHandlers;
using BikeRental.StationService.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BikeRental.StationService
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

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateStationCommand command)
        {
            try
            {
                command.Id = id;
                await _mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _mediator.Send(new DeleteStationCommand { Id = id });
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

        [HttpGet("{stationId}/bikes")]
        public async Task<ActionResult<IEnumerable<BikeResponse>>> GetBikes(int stationId)
        {
            try
            {
                return Ok(await _mediator.Send(new GetBikesAtStationQuery { StationId = stationId }));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }

    }
}
