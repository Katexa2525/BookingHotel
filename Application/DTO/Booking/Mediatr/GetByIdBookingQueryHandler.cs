using Application.DTO.Booking.CQRS;
using MediatR;

namespace Application.DTO.Booking.Mediatr
{
  public class GetByIdBookingQueryHandler : IRequestHandler<GetByIdBookingQuery, BookingDto>
  {
    public Task<BookingDto> Handle(GetByIdBookingQuery request, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }
  }
}
