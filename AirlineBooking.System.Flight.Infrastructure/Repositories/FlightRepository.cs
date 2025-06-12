using AirlineBooking.System.Flights.Core.Entities;
using AirlineBooking.System.Flights.Infrastructure.Data;
using MongoDB.Driver;

namespace AirlineBooking.System.Flights.Infrastructure.Repositories;
public class FlightRepository : IFlightRepository
{
    private readonly IFlightContext _context;
    public FlightRepository(IFlightContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task AddFlightAsync(Flight flight)
    {
        await _context.Flights.InsertOneAsync(flight);
    }

    public async Task DeleteFlightAsync(Guid id)
    {
        await _context.Flights.DeleteOneAsync(f => f.Id == id);
    }
     
    public async Task<IEnumerable<Flight>> GetFlightsAsync()
    {
        return await _context.Flights.Find(_ => true).ToListAsync();
    }
}
