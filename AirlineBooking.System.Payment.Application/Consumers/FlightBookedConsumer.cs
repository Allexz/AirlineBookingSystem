using AirlineBooking.System.Payments.Application.Commands;
using AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Messages;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBooking.System.Payments.Application.Consumers;
public class FlightBookedConsumer : IConsumer<FlightBookedEvent>
{
    private readonly IMediator _mediator;
    public FlightBookedConsumer(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Consume(ConsumeContext<FlightBookedEvent> context)
    {
        var flightBookedEvent = context.Message;
        var command = new ProcessPaymentCommand(flightBookedEvent.BookingId, 200.00m);
        await _mediator.Send(command);
    }
}
