using MediatR;

namespace Application.DTO.Booking.CQRS
{
  public class GetByIdBookingQuery : IRequest<BookingDto>
  {
    public Guid Id { get; set; }
  }
}
