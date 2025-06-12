using AirlineBooking.System.Flights.Application.Commands;
using AirlineBooking.System.Flights.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBooking.System.Flights.Application.Handlers;
public class DeleteFlightHandler : IRequestHandler<DeleteFlightCommand>
{
    private readonly IFlightRepository _flightRepository;
    public DeleteFlightHandler(IFlightRepository flightRepository)
    {
        _flightRepository = flightRepository ?? throw new ArgumentNullException(nameof(flightRepository));
    }
    public async Task Handle(DeleteFlightCommand request, CancellationToken cancellationToken)
    {
         await _flightRepository.DeleteFlightAsync(request.Id);
    }
}
