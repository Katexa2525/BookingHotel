using MediatR;

namespace Application.DTO.Booking.CQRS
{
  public class GetAllBookingQuery : IRequest<List<BookingAllDto>>
  {
  }
}
