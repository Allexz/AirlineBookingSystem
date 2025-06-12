using AirlineBooking.System.Payments.Core.Entities;

namespace AirlineBooking.System.Payments.Core.Repositories;
public interface IPaymentRepository
{
    Task ProcessPaymentAsynct(Payment payment);
    Task RefundPaymentAsync(Guid paymentId);
}
