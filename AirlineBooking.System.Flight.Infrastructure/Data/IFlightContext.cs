using AirlineBooking.System.Flights.Core.Entities;
using MongoDB.Driver;

namespace AirlineBooking.System.Flights.Infrastructure.Data;
public interface IFlightContext
{
    IMongoCollection<Flight> Flights { get; }
}
