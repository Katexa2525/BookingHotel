using Application.BussinessLogic.Booking;
using Application.DTO.Booking.CQRS;
using MediatR;

namespace Application.DTO.Booking.Mediatr
{
  public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, Guid>
  {
    private readonly IBookingBussinessLogic _bussinessLogic;

    public CreateBookingCommandHandler(IBookingBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }

    public async Task<Guid> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.CreateAsync(request.Dto);
    }
  }
}
