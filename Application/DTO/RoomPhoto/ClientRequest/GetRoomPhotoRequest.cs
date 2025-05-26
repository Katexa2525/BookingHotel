using MediatR;

namespace Application.DTO.RoomPhoto.ClientRequest
{
  public record GetRoomPhotoRequest(Guid photoId) : IRequest<GetRoomPhotoRequest.Response>
  {
    public const string RouteTemplate = "/api/roomphotos/{photoId}";

    public record Response(RoomPhotoDto? RoomPhoto);
  }
}
