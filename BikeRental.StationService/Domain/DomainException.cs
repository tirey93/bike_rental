﻿namespace BikeRental.StationService.Domain
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message) { }
    }
}
