using MediatR;

namespace Application.DTO.Room.CQRS
{
  public class CreateRoomCommand : IRequest<Guid>
  {
    public RoomCreateDto Dto { get; set; }
  }
}
