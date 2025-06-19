using MediatR;

namespace Application.DTO.Booking.CQRS
{
  public class GetAllBookingByUserIdQuery : IRequest<List<BookingDto>>
  {
    public string? UserId { get; set; }
  }
}
