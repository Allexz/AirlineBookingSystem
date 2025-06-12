using MediatR;

namespace AirlineBooking.System.Flights.Application.Commands;
public record DeleteFlightCommand(Guid Id) : IRequest ;
