using MediatR;

namespace Application.DTO.Room.CQRS
{
  public class GetByIdRoomQuery : IRequest<RoomDto>
  {
    public Guid Id { get; set; }
  }
}
