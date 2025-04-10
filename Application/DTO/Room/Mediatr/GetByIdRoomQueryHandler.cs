using Application.BussinessLogic.Room;
using Application.DTO.Room.CQRS;
using MediatR;

namespace Application.DTO.Room.Mediatr
{
  public class GetByIdRoomQueryHandler : IRequestHandler<GetByIdRoomQuery, RoomDto>
  {
    private readonly IRoomBussinessLogic _bussinessLogic;
    public GetByIdRoomQueryHandler(IRoomBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }
    public async Task<RoomDto> Handle(GetByIdRoomQuery request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.GetByIdAsync(request.Id);
    }
  }
}
