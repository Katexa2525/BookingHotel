using Application.DTO.Hotel.ClientRequest;
using MediatR;

namespace Application.DTO.Booking.ClientRequest
{
  public record GetBookingsRequest : IRequest<GetHotelsRequest.Response>
  {
    public const string RouteTemplate = "api/bookings";

    public record Response(List<BookingAllDto>? Bookings);
  }
}
