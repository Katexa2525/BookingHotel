using MediatR;

namespace Application.DTO.RoomPhoto.CQRS
{
  public class GetByIdRoomPhotoQuery : IRequest<RoomPhotoDto>
  {
    public Guid Id { get; set; }
  }
}
