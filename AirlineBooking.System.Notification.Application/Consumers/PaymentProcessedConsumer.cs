using AirlineBooking.System.Notifications.Application.Commands;
using AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Messages;
using MassTransit;
using MediatR;

namespace AirlineBooking.System.Notifications.Application.Consumers;
public class PaymentProcessedConsumer : IConsumer<PaymentProcessedEvent>
{
    private readonly IMediator _mediator;

    public PaymentProcessedConsumer(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Consume(ConsumeContext<PaymentProcessedEvent> context)
    {
        var paymentProcessedEvent = context.Message;
        var message  = $"Payment processed for booking {paymentProcessedEvent.BookingId} with amount {paymentProcessedEvent.Amount} on {paymentProcessedEvent.PaymentDate}.";

        var command = new SendNotificationCommand("mail@mail.com",message, "Email");
        await _mediator.Send(command);

    }
}
