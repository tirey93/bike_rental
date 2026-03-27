using BikeRental.BikeAtStationService.Application.QueryHandlers;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BikeAtStationResponse>>> GetAll()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllBikeAtStationsQuery()));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }
    }
}
