using MediatR;

namespace Application.DTO.Room.CQRS
{
  public class UpdateRoomCommand : IRequest<Unit>
  {
    public RoomUpdateDto Dto { get; set; }
  }
}
