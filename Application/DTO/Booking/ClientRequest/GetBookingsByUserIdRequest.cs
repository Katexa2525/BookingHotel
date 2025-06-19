using MediatR;

namespace Application.DTO.Booking.ClientRequest
{
  public record GetBookingsByUserIdRequest(string userId) : IRequest<GetBookingsByUserIdRequest.Response>
  {
    public const string RouteTemplate = "api/bookings/{userId}/bookings";

    public record Response(List<BookingDto>? Booking);
  }
}
