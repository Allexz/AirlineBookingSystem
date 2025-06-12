using MediatR;

namespace AirlineBooking.System.Notifications.Application.Commands;
public record SendNotificationCommand(string Recipient, string Message, string Type): IRequest;
