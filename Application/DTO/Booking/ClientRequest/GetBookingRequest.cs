using MediatR;

namespace Application.DTO.Booking.ClientRequest
{
  public record GetBookingRequest(Guid bookingId) : IRequest<GetBookingRequest.Response>
  {
    public const string RouteTemplate = "/api/bookings/{bookingId}";

    public record Response(BookingDto? Booking);
  }
}
