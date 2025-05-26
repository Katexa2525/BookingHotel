using MediatR;

namespace Application.DTO.RoomPhoto.ClientRequest
{
  public record DeleteRoomPhotoRequest(Guid photoId) : IRequest<DeleteRoomPhotoRequest.Response>
  {
    public const string RouteTemplate = "api/roomphotos/{photoId}";

    public record Response(bool IsSuccess);
  }
}
