using Application.BussinessLogic.Hotel;
using Application.DTO.Hotel.CQRS;
using MediatR;

namespace Application.DTO.Hotel.Mediatr
{
  public class UpdateHotelCommandHandler : IRequestHandler<UpdateHotelCommand, Unit>
  {
    private readonly IHotelBussinessLogic _bussinessLogic;
    public UpdateHotelCommandHandler(IHotelBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }
    public async Task<Unit> Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
    {
      await _bussinessLogic.UpdateAsync(request.Dto);
      return Unit.Value;
    }
  }
}
