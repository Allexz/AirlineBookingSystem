namespace AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Messages;
public record PaymentProcessedEvent( Guid BookingId,
                                    Guid PaymentId,
                                    decimal Amount,
                                    DateTime PaymentDate);
 