using Application.BussinessLogic.RoomType;
using Application.DTO.RoomType.CQRS;
using MediatR;

namespace Application.DTO.RoomType.Mediatr
{
  public class GetAllRoomTypeQueryHandler : IRequestHandler<GetAllRoomTypeQuery, List<RoomTypeAllDto>>
  {
    private readonly IRoomTypeBussinessLogic _bussinessLogic;

    public GetAllRoomTypeQueryHandler(IRoomTypeBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }

    public async Task<List<RoomTypeAllDto>> Handle(GetAllRoomTypeQuery request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.GetAllAsync(trackChanges: false);
    }
  }
}
