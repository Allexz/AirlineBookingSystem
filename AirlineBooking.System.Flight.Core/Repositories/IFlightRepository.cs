namespace AirlineBooking.System.Flights.Core.Entities;
public interface IFlightRepository
{
    Task<IEnumerable<Flight>> GetFlightsAsync(); 
    Task DeleteFlightAsync(Guid id);  
    
    Task AddFlightAsync(Flight flight);
}
