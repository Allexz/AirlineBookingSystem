using AirlineBooking.System.Notifications.Core.Entities;
using AirlineBooking.System.Notifications.Core.Repositories;
using Dapper;
using System;
using System.Data;
using System.Threading.Tasks;

namespace AirlineBooking.System.Notifications.Infrastructure.Repositories;
public class NotificationRepository : INotificationRepository
{
    private readonly IDbConnection _dbConnection;
    public NotificationRepository(IDbConnection dbConnection)
    {
            _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
    }
    public async Task LogNotificationAsync(Notification notification)
    {
        const string sql = @"INSERT INTO Notifications (Id,Recipient, Message,Type,SentAt) VALUES (@Id, @Recipient, @Message, @Type, @SentAt)";

       await _dbConnection.ExecuteAsync(sql,notification);
    }
}
