﻿using AirlineBooking.System.Payments.Application.Commands;
using AirlineBooking.System.Payments.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBooking.System.Payments.Application.Handlers;
public class RefundPaymentHandler : IRequestHandler<RefundPaymentCommand>
{
    private readonly IPaymentRepository _paymentRepository;
    public RefundPaymentHandler(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }
    public async Task Handle(RefundPaymentCommand request, CancellationToken cancellationToken)
    {
        await _paymentRepository.RefundPaymentAsync(request.Id);
    }
}
