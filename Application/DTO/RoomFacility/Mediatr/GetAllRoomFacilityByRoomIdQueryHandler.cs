using Application.BussinessLogic.RoomFacility;
using Application.DTO.RoomFacility.CQRS;
using MediatR;

namespace Application.DTO.RoomFacility.Mediatr
{
  public class GetAllRoomFacilityByRoomIdQueryHandler : IRequestHandler<GetAllRoomFacilityByRoomIdQuery, List<RoomFacilityDto>>
  {
    private readonly IRoomFacilityBussinessLogic _bussinessLogic;

    public GetAllRoomFacilityByRoomIdQueryHandler(IRoomFacilityBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }

    public async Task<List<RoomFacilityDto>> Handle(GetAllRoomFacilityByRoomIdQuery request, CancellationToken cancellationToken)
    {
      return _bussinessLogic.GetByCondition(p => p.RoomId == request.RoomId, trackChanges: false);
    }
  }
}
