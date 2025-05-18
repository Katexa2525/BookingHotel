using Application.BussinessLogic.RoomFacility;
using Application.DTO.RoomFacility.CQRS;
using MediatR;

namespace Application.DTO.RoomFacility.Mediatr
{
  public class GetAllRoomFacilityQueryHandler : IRequestHandler<GetAllRoomFacilityQuery, List<RoomFacilityDto>>
  {
    private readonly IRoomFacilityBussinessLogic _bussinessLogic;
    public GetAllRoomFacilityQueryHandler(IRoomFacilityBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }
    public async Task<List<RoomFacilityDto>> Handle(GetAllRoomFacilityQuery request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.GetAllAsync(trackChanges: true); 
    }
  }
}
