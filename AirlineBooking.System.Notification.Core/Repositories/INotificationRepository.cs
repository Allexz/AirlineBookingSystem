using AirlineBooking.System.Notifications.Core.Entities;

namespace AirlineBooking.System.Notifications.Core.Repositories;
public interface INotificationRepository
{
    Task LogNotificationAsync(Notification notification);
}
