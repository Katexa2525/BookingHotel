using MediatR;

namespace Application.DTO.RoomPhoto.ClientRequest
{
  public record EditRoomPhotoRequest(RoomPhotoDto roomPhoto) : IRequest<EditRoomPhotoRequest.Response>
  {
    public const string RouteTemplate = "api/roomphotos/edit";
    public record Response(bool IsSuccess);
  }
}
