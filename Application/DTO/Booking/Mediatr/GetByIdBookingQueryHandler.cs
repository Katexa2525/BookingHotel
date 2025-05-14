using Application.BussinessLogic.Booking;
using Application.DTO.Booking.CQRS;
using MediatR;

namespace Application.DTO.Booking.Mediatr
{
  public class GetByIdBookingQueryHandler : IRequestHandler<GetByIdBookingQuery, BookingDto>
  {
    private readonly IBookingBussinessLogic _bussinessLogic;

    public GetByIdBookingQueryHandler(IBookingBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }

    public async Task<BookingDto> Handle(GetByIdBookingQuery request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.GetByIdAsync(request.Id, trackChanges: true);
    }
  }
}
