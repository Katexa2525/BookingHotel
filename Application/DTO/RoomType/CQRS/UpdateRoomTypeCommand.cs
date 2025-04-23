using MediatR;

namespace Application.DTO.RoomType.CQRS
{
  public class UpdateRoomTypeCommand : IRequest<Unit>
  {
    public RoomTypeUpdateDto Dto { get; set; }
  }
}
