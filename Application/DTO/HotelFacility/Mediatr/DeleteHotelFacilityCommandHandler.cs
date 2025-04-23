using Application.BussinessLogic.HotelFacility;
using Application.DTO.HotelFacility.CQRS;
using MediatR;

namespace Application.DTO.HotelFacility.Mediatr
{
  public class DeleteHotelFacilityCommandHandler : IRequestHandler<DeleteHotelFacilityCommand, Unit>
  {
    private readonly IHotelFacilityBussinessLogic _bussinessLogic;
    public DeleteHotelFacilityCommandHandler(IHotelFacilityBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }
    public async Task<Unit> Handle(DeleteHotelFacilityCommand request, CancellationToken cancellationToken)
    {
      await _bussinessLogic.DeleteAsync(request.HotelFacilityId);
      return Unit.Value;
    }
  }
}
