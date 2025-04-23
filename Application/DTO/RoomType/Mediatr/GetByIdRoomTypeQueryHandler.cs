using Application.DTO.RoomType.CQRS;
using MediatR;

namespace Application.DTO.RoomType.Mediatr
{
  public class GetByIdRoomTypeQueryHandler : IRequestHandler<GetByIdRoomTypeQuery, RoomTypeDto>
  {
    public Task<RoomTypeDto> Handle(GetByIdRoomTypeQuery request, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }
  }
}
