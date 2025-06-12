using AirlineBooking.System.Notifications.Application.Commands;
using AirlineBooking.System.Notifications.Application.Interfaces;
using AirlineBooking.System.Notifications.Core.Entities;
using MediatR;

namespace AirlineBooking.System.Notifications.Application.Handlers;
public class SendNotificationHandler : IRequestHandler<SendNotificationCommand>
{
    private readonly INotificationServices _notificationServices;
    public SendNotificationHandler(INotificationServices services)
    {
        _notificationServices = services ?? throw new ArgumentNullException(nameof(services));
    }
    public async Task Handle(SendNotificationCommand request, CancellationToken cancellationToken)
    {
        Notification notification = new Notification
        {
            Id = Guid.NewGuid(),
            Recipient = request.Recipient,
            Message = request.Message,
            Type = request.Type
        };
        await _notificationServices.SendNotificationAsync(notification);
    }
}
 