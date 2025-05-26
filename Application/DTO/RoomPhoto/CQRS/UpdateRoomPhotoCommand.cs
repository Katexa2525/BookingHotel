using Application.DTO.Price;
using MediatR;

namespace Application.DTO.RoomPhoto.CQRS
{
  public class UpdateRoomPhotoCommand : IRequest<Unit>
  {
    public RoomPhotoDto Dto { get; set; }
  }
}
