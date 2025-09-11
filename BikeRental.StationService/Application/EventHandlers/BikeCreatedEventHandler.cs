using BikeRental.BikeService.Contracts.Events;
using Rebus.Handlers;

namespace BikeRental.StationService.Application.EventHandlers
{
    public class BikeCreatedEventHandler : IHandleMessages<BikeCreatedEvent>
    {
        private readonly ILogger<BikeCreatedEventHandler> _logger;

        public BikeCreatedEventHandler(ILogger<BikeCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(BikeCreatedEvent message)
        {
            await Task.CompletedTask;
        }
    }
}
