using AirlineBooking.System.Flights.Application.Queries;
using AirlineBooking.System.Flights.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBooking.System.Flights.Application.Handlers;
public class GetAllFlightHandler : IRequestHandler<GetAllFlightQuery, IEnumerable<Flight>>
{
    private readonly IFlightRepository _flightRepository;
    public GetAllFlightHandler(IFlightRepository  flightRepository)
    {
        _flightRepository = flightRepository ?? throw new ArgumentNullException(nameof(flightRepository));
    }
    public async Task<IEnumerable<Flight>> Handle(GetAllFlightQuery request, CancellationToken cancellationToken)
    {
         return await _flightRepository.GetFlightsAsync();
    }
}
