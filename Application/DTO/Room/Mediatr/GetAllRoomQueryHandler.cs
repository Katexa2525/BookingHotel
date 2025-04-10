using Application.BussinessLogic.Room;
using Application.DTO.Room.CQRS;
using MediatR;

namespace Application.DTO.Room.Mediatr
{
  public class GetAllRoomQueryHandler : IRequestHandler<GetAllRoomQuery, List<RoomAllDto>>
  {
    private readonly IRoomBussinessLogic _bussinessLogic;
    public GetAllRoomQueryHandler(IRoomBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }
    public async Task<List<RoomAllDto>> Handle(GetAllRoomQuery request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.GetAllAsync();
    }
  }
}
