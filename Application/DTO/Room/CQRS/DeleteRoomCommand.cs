using MediatR;

namespace Application.DTO.Room.CQRS
{
  public class DeleteRoomCommand : IRequest<Unit>
  {
    public Guid RoomId { get; set; }
  }
}
