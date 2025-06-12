using AirlineBooking.System.Flights.Application.Commands;
using AirlineBooking.System.Flights.Application.Handlers;
using AirlineBooking.System.Flights.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBooking.System.Flight.Api.Controllers;
[ApiController]
[Route("api/flights")]
public class FlightController : ControllerBase
{
    private readonly IMediator _mediator;
    public FlightController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetFlights()
    {
        var flights = await _mediator.Send(new GetAllFlightQuery());
        return Ok(flights);
    }

    [HttpPost]
    public async Task<IActionResult> AddFlight([FromBody] CreateFlightCommand command)
    {
        var flightId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetFlights), new { id = flightId }, command);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFlight(Guid id)
    {
        await _mediator.Send(new DeleteFlightCommand(id));
        return NoContent();
    }   
}
