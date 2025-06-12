using MediatR;

namespace AirlineBooking.System.Flights.Application.Commands;
public record CreateFlightCommand(string FlightNumber,
                                  string Origin,
                                  string Destination,
                                  DateTime DepartureTime,
                                  DateTime ArrivalTime) : IRequest<Guid>;
 