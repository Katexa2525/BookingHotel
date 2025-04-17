using MediatR;

namespace Application.DTO.RoomPhoto.CQRS
{
  public class CreateRoomPhotoCommand : IRequest<Guid>
  {
    public RoomPhotoCreateWithIdDto Dto { get; set; }
  }
}
