using MediatR;

namespace Application.DTO.Booking.CQRS
{
  public class DeleteBookingCommand : IRequest<Unit>
  {
    public Guid BookingId { get; set; }
  }
}
