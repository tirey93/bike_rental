using BikeRental.BikeService.Application.CommandHandlers;
using BikeRental.BikeService.Application.QueryHandlers;
using BikeRental.BikeService.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BikeRental.BikeService
{
    [ApiController]
    [Route("[controller]")]
    public class BikeController : ControllerBase
    {
        private readonly ILogger<BikeController> _logger;
        private readonly IMediator _mediator;

        public BikeController(ILogger<BikeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateBikeCommand command)
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BikeResponse>>> GetAll()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllBikesQuery()));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }
    }
}
