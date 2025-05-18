using Application.BussinessLogic.RoomFacility;
using Application.DTO.RoomFacility.CQRS;
using MediatR;

namespace Application.DTO.RoomFacility.Mediatr
{
  public class GetByIdRoomFacilityQueryHandler : IRequestHandler<GetByIdRoomFacilityQuery, RoomFacilityDto>
  {
    private readonly IRoomFacilityBussinessLogic _bussinessLogic;
    public GetByIdRoomFacilityQueryHandler(IRoomFacilityBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }
    public async Task<RoomFacilityDto> Handle(GetByIdRoomFacilityQuery request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.GetByIdAsync(request.Id, trackChanges: true);
    }
  }
}
