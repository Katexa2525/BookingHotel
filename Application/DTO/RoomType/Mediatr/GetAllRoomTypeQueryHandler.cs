using Application.DTO.RoomType.CQRS;
using MediatR;

namespace Application.DTO.RoomType.Mediatr
{
  public class GetAllRoomTypeQueryHandler : IRequestHandler<GetAllRoomTypeQuery, List<RoomTypeAllDto>>
  {
    public Task<List<RoomTypeAllDto>> Handle(GetAllRoomTypeQuery request, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }
  }
}
