using MediatR;

namespace Application.DTO.RoomType.CQRS
{
  public class CreateRoomTypeCommand : IRequest<Guid>
  {
    public RoomTypeCreateDto Dto { get; set; }
  }
}
