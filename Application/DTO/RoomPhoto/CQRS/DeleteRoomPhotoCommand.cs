using MediatR;

namespace Application.DTO.RoomPhoto.CQRS
{
  public class DeleteRoomPhotoCommand : IRequest<Unit>
  {
    public Guid RoomPhotoId { get; set; }
  }
}
