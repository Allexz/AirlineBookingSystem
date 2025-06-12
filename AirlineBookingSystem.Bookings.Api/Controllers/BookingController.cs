using AirlineBookingSystem.Bookings.Application.Commands;
using AirlineBookingSystem.Bookings.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingSystem.Bookings.Api.Controllers;
[Route("api/bookings")]
[ApiController]
public class BookingController : ControllerBase
{
    private readonly IMediator _mediator;
    public BookingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> AddBooking([FromBody] CreateBookingCommand command)
    {
        var bookingId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetBookingById), new { id = bookingId },command);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookingById(Guid id)
    {
        var booking = await _mediator.Send(new GetBookingQuery(id));
        return Ok(booking);

    }


}
