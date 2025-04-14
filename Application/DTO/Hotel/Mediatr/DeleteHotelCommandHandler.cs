using Application.BussinessLogic.Hotel;
using Application.DTO.Hotel.CQRS;
using MediatR;

namespace Application.DTO.Hotel.Mediatr
{
  public class DeleteHotelCommandHandler : IRequestHandler<DeleteHotelCommand, Unit>
  {
    private readonly IHotelBussinessLogic _bussinessLogic;
    public DeleteHotelCommandHandler(IHotelBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }
    public async Task<Unit> Handle(DeleteHotelCommand request, CancellationToken cancellationToken)
    {
      await _bussinessLogic.DeleteAsync(request.HotelId);
      return Unit.Value;
    }
  }
}
