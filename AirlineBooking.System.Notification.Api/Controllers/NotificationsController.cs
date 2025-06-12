using AirlineBooking.System.Notifications.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBooking.System.Notification.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class NotificationsController : ControllerBase
{
    private readonly IMediator _mediator;
    public NotificationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> SendNotification([FromBody] SendNotificationCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }



}
