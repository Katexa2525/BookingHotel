using Application.BussinessLogic.Booking;
using Application.DTO.Booking.CQRS;
using MediatR;

namespace Application.DTO.Booking.Mediatr
{
  public class GetAllBookingQueryHandler : IRequestHandler<GetAllBookingQuery, List<BookingAllDto>>
  {
    private readonly IBookingBussinessLogic _bussinessLogic;

    public GetAllBookingQueryHandler(IBookingBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }

    public async Task<List<BookingAllDto>> Handle(GetAllBookingQuery request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.GetAllAsync(trackChanges: true);
    }
  }
}
