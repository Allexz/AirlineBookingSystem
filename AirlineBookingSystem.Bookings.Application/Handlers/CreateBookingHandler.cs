using AirlineBookingSystem.Bookings.Application.Commands;
using AirlineBookingSystem.Bookings.Core.Entities;
using AirlineBookingSystem.Bookings.Core.Repositories;
using AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Messages;
using MassTransit;
using MediatR;

namespace AirlineBookingSystem.Bookings.Application.Handlers;
public class CreateBookingHandler : IRequestHandler<CreateBookingCommand, Guid>
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IPublishEndpoint _publishEndpoint;
    public CreateBookingHandler(IBookingRepository bookingRepository, IPublishEndpoint publishEndpoint)
    {
        _bookingRepository = bookingRepository ?? throw new ArgumentNullException(nameof(bookingRepository));
        _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
    }
    public async Task<Guid> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        Booking booking = new Booking
        {
            Id = Guid.NewGuid(),
            FlightId = request.FlightId,
            PassengerName = request.PassengerName,
            SeatNumber = request.SeatNumber,
            BookingDate = DateTime.UtcNow
        };

        await _bookingRepository.AddBookingAsync(booking);

        await _publishEndpoint.Publish(new FlightBookedEvent(
           booking.Id,
           booking.FlightId,
           booking.PassengerName,
           booking.SeatNumber,
           booking.BookingDate));
        return booking.Id;
    }
}
