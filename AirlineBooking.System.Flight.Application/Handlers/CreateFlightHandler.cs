using AirlineBooking.System.Flights.Application.Commands;
using AirlineBooking.System.Flights.Core.Entities;
using MediatR;

namespace AirlineBooking.System.Flights.Application.Handlers;
public class CreateFlightHandler : IRequestHandler<CreateFlightCommand, Guid>
{
    private readonly IFlightRepository _flightRepository;
    public CreateFlightHandler(IFlightRepository flightRepository)
    {
        _flightRepository = flightRepository ?? throw new ArgumentNullException(nameof(flightRepository));
    }
    public async Task<Guid> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
    {
        Flight flight =  new Flight
        {
            Id = Guid.NewGuid(),
            FlightNumber = request.FlightNumber,
            Origin = request.Origin,
            Destination = request.Destination,
            DepartureTime = request.DepartureTime,
            ArrivalTime = request.ArrivalTime
        };
        await _flightRepository.AddFlightAsync(flight);
        return flight.Id;
    }
}
