using Application.BussinessLogic.HotelFacility;
using Application.DTO.HotelFacility.CQRS;
using MediatR;

namespace Application.DTO.HotelFacility.Mediatr
{
  public class UpdateHotelFacilityCommandHandler : IRequestHandler<UpdateHotelFacilityCommand, Unit>
  {
    private readonly IHotelFacilityBussinessLogic _bussinessLogic;
    public UpdateHotelFacilityCommandHandler(IHotelFacilityBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }
    public async Task<Unit> Handle(UpdateHotelFacilityCommand request, CancellationToken cancellationToken)
    {
      await _bussinessLogic.UpdateAsync(request.Dto);
      return Unit.Value;
    }
  }
}
