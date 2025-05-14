using Application.BussinessLogic.Booking;
using Application.DTO.Booking.CQRS;
using MediatR;

namespace Application.DTO.Booking.Mediatr
{
  public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, Unit>
  {
    private readonly IBookingBussinessLogic _bussinessLogic;

    public UpdateBookingCommandHandler(IBookingBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }

    public async Task<Unit> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
    {
      await _bussinessLogic.UpdateAsync(request.Dto);
      return Unit.Value;
    }
  }
}
