using Application.BussinessLogic.Booking;
using Application.DTO.Booking.CQRS;
using MediatR;

namespace Application.DTO.Booking.Mediatr
{
  public class GetAllBookingByUserIdQueryHandler : IRequestHandler<GetAllBookingByUserIdQuery, List<BookingDto>>
  {
    private readonly IBookingBussinessLogic _bussinessLogic;

    public GetAllBookingByUserIdQueryHandler(IBookingBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }

    public async Task<List<BookingDto>> Handle(GetAllBookingByUserIdQuery request, CancellationToken cancellationToken)
    {
      return _bussinessLogic.GetByCondition(p => p.UserId == request.UserId, trackChanges: false);
    }
  }
}
