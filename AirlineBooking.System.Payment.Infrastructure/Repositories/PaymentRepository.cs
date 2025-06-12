using AirlineBooking.System.Payments.Core.Entities;
using AirlineBooking.System.Payments.Core.Repositories;
using Dapper;
using System.Data;

namespace AirlineBooking.System.Payments.Infrastructure.Repositories;
public class PaymentRepository : IPaymentRepository
{
    private readonly IDbConnection _dbConnection;
    public PaymentRepository(IDbConnection dbConnection)
    {
        _dbConnection
            = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
    }
    public async Task ProcessPaymentAsynct(Payment payment)
    {
       const string sql = @"INSERT INTO Payments (Id, BookingId, Amount, PaymentDate) VALUES (@Id, @BookingId, @Amount, @PaymentDate)";
        await _dbConnection.ExecuteAsync(sql, payment);
    }

    public async Task RefundPaymentAsync(Guid paymentId)
    {
        const string sql = @"DELETE FROM payments WHERE Id = @Id";
        await _dbConnection.ExecuteAsync(sql, new { Id = paymentId });
    }
}
