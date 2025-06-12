using AirlineBooking.System.Flights.Core.Entities;
using MediatR;

namespace AirlineBooking.System.Flights.Application.Queries;
public record GetAllFlightQuery: IRequest<IEnumerable<Flight>>;
