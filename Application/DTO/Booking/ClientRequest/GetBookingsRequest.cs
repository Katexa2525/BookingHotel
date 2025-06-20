using MediatR;

namespace Application.DTO.Booking.ClientRequest
{
  public record GetBookingsRequest : IRequest<GetBookingsRequest.Response>
  {
    public const string RouteTemplate = "api/bookings";

    public record Response(List<BookingDto>? Bookings);
  }
}
