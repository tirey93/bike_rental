using MediatR;
using Rebus.Bus;
using Rebus.Handlers;

namespace BikeRental.StationService.Events
{
    public class BikeCreatedEvent
    {
        public Guid ExternalBikeId { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public DateOnly LastServiceDate { get; set; }

    }

    //public class BikeCreatedEventHandler : IHandleMessages<BikeCreatedEvent>
    //{
    //    private readonly ILogger<BikeCreatedEventHandler> _logger;

    //    public BikeCreatedEventHandler(ILogger<BikeCreatedEventHandler> logger)
    //    {
    //        _logger = logger;
    //    }

    //    public async Task Handle(BikeCreatedEvent message)
    //    {
    //        await Task.CompletedTask;
    //    }
    //}

}