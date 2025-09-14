using BikeRental.StationService.Contracts.Events;
using Rebus.Handlers;

namespace BikeRental.BikeService.Application.EventHandlers
{
    public class BikeAtStationAddedEventHandler : IHandleMessages<BikeAtStationAddedEvent>
    {
        public Task Handle(BikeAtStationAddedEvent message)
        {
            return Task.CompletedTask;
        }
    }
}
