using MediatR;

namespace Application.DTO.Booking.ClientRequest
{
  public record EditBookingRequest(BookingDto booking) : IRequest<EditBookingRequest.Response>
  {
    public const string RouteTemplate = "api/bookings/edit";
    public record Response(bool IsSuccess);
  }
}
