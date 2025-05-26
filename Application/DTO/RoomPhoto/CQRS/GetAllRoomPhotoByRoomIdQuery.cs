using MediatR;

namespace Application.DTO.RoomPhoto.CQRS
{
  public class GetAllRoomPhotoByRoomIdQuery : IRequest<List<RoomPhotoDto>>
  {
    public Guid RoomId { get; set; }
  }
}
