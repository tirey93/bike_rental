namespace BikeRental.StationService.Domain.Entities
{
    public class Station : Entity
    {
        public string Code { get; set; }

        public string Location { get; set; }

        public int Capacity { get; set; }
    }
}
