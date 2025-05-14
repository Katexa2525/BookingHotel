using MediatR;

namespace Application.DTO.Booking.CQRS
{
  public class CreateBookingCommand : IRequest<Guid>
  {
    public BookingCreateDto Dto { get; set; }
  }
}
