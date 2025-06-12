using AirlineBooking.System.Notifications.Application.Interfaces;
using AirlineBooking.System.Notifications.Core.Entities;
using AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Messages;
using MassTransit;

namespace AirlineBooking.System.Notifications.Application.Services;
public class NotificationServices : INotificationServices
{
    private readonly IPublishEndpoint _publishEndpoint;

    public NotificationServices(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async Task SendNotificationAsync(Notification notification)
    {
        //Simulate sending notification
        Console.WriteLine($"Sending notification to {notification.Recipient}: {notification.Message} of type {notification.Type}");

        var notificationEvent = new NotificationEvent(notification.Recipient,
                                                      notification.Message,
                                                      notification.Type); 

        await _publishEndpoint.Publish(notificationEvent);
    }
}
