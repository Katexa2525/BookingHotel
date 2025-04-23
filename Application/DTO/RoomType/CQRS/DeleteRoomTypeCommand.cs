using MediatR;

namespace Application.DTO.RoomType.CQRS
{
  public class DeleteRoomTypeCommand : IRequest<Unit>
  {
    public Guid RoomTypeId { get; set; }
  }
}
