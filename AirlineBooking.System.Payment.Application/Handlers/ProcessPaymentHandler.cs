using AirlineBooking.System.Payments.Application.Commands;
using AirlineBooking.System.Payments.Core.Entities;
using AirlineBooking.System.Payments.Core.Repositories;
using AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Messages;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBooking.System.Payments.Application.Handlers;
public class ProcessPaymentHandler: IRequestHandler<ProcessPaymentCommand, Guid>
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IPublishEndpoint _publishEndpoint;

    public ProcessPaymentHandler(IPaymentRepository paymentRepository, IPublishEndpoint publishEndpoint)
    {
        _paymentRepository = paymentRepository;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<Guid> Handle(ProcessPaymentCommand request, CancellationToken cancellationToken)
    {
        Payment payment = new Payment
        {
            Id = Guid.NewGuid(),
            BookingId = request.BookingId,
            Amount = request.Amount,
            PaymentDate = DateTime.UtcNow
        };
        await _paymentRepository.ProcessPaymentAsynct (payment);
        await _publishEndpoint.Publish(new PaymentProcessedEvent(
            payment.Id,
            payment.BookingId,
            payment.Amount,
            payment.PaymentDate));
         
        return payment.Id;
    }
}
 
