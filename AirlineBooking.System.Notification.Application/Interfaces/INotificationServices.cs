using AirlineBooking.System.Notifications.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBooking.System.Notifications.Application.Interfaces;
public interface INotificationServices
{
    Task SendNotificationAsync(Notification notification);
}
