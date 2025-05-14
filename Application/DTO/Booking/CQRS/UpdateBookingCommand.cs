using MediatR;

namespace Application.DTO.Booking.CQRS
{
  public class UpdateBookingCommand : IRequest<Unit>
  {
    public BookingUpdateDto Dto { get; set; }
  }
}
