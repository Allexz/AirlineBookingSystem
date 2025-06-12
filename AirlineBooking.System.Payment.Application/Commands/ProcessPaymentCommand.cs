using MediatR;

namespace AirlineBooking.System.Payments.Application.Commands;
public record ProcessPaymentCommand(Guid BookingId, decimal Amount) :IRequest<Guid>;
