using MediatR;

namespace AirlineBooking.System.Payments.Application.Commands;
public record RefundPaymentCommand(Guid Id): IRequest;  
