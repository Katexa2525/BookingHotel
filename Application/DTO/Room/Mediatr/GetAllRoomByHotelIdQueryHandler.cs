using Application.BussinessLogic.Room;
using Application.DTO.Room.CQRS;
using MediatR;

namespace Application.DTO.Room.Mediatr
{
  public class GetAllRoomByHotelIdQueryHandler : IRequestHandler<GetAllRoomByHotelIdQuery, List<RoomDto>>
  {
    private readonly IRoomBussinessLogic _bussinessLogic;

    public GetAllRoomByHotelIdQueryHandler(IRoomBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }

    public async Task<List<RoomDto>> Handle(GetAllRoomByHotelIdQuery request, CancellationToken cancellationToken)
    {
      return _bussinessLogic.GetByCondition(p=>p.HotelId == request.HotelId, trackChanges: false);
    }
  }
}
