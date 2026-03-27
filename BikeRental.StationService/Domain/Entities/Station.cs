using BikeRental.StationService.Domain.Entities.External;

namespace BikeRental.StationService.Domain.Entities
{
    public class Station : ExternalEntity
    {
        public string Code { get; set; }

        public string Location { get; set; }

        public int Capacity { get; set; }

        public ICollection<BikeAtStation> BikesAtStation { get; private set; } = [];
    }
}
