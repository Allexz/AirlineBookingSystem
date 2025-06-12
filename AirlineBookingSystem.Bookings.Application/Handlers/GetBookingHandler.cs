﻿using AirlineBookingSystem.Bookings.Application.Queries;
using AirlineBookingSystem.Bookings.Core.Entities;
using AirlineBookingSystem.Bookings.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Bookings.Application.Handlers;
public class GetBookingHandler
    : IRequestHandler<GetBookingQuery, Booking>
{
    private readonly IBookingRepository _bookingRepository;
    public GetBookingHandler(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository ?? throw new ArgumentNullException(nameof(bookingRepository));
    }
    public async Task<Booking> Handle(GetBookingQuery request, CancellationToken cancellationToken)
    {
        return await _bookingRepository.GetBookingByIdAsync(request.Id);
    }
}
 