using Rebus.Handlers;

namespace BikeRental.BikeService.Events
{
    public class BikeCreatedEvent
    {
        public Guid ExternalBikeId { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public DateOnly LastServiceDate { get; set; }

    }

    public class BikeCreatedEventHandler : IHandleMessages<string>
    {
        private readonly ILogger<BikeCreatedEventHandler> _logger;

        public BikeCreatedEventHandler(ILogger<BikeCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(string message)
        {
            await Task.CompletedTask;
        }
    }
}
