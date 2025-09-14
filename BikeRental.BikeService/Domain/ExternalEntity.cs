namespace BikeRental.BikeService.Domain
{
    public class ExternalEntity : Entity
    {
        public Guid ExternalId { get; private set; }

        public ExternalEntity()
        {
            ExternalId = Guid.NewGuid();
        }

        public ExternalEntity(Guid externalId)
        {
            ExternalId = externalId;
        }
    }
}
