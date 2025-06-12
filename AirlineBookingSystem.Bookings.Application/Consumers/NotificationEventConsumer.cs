using AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Messages;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Bookings.Application.Consumers;
public class NotificationEventConsumer : IConsumer<NotificationEvent>
{
    public async Task Consume(ConsumeContext<NotificationEvent> context)
    {
        var notificationEvent = context.Message;
        Console.WriteLine($"Receive Notification event:" +
            $" Recipient: {notificationEvent.Recipient} with message: {notificationEvent.Message} of type {notificationEvent.Type}");
        await Task.CompletedTask;
    }
}
