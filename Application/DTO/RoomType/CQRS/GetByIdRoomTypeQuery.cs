using MediatR;

namespace Application.DTO.RoomType.CQRS
{
  public class GetByIdRoomTypeQuery : IRequest<RoomTypeDto>
  {
    public Guid Id { get; set; }
  }
}
