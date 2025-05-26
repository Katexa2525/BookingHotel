using MediatR;

namespace Application.DTO.RoomPhoto.ClientRequest
{
  public record AddRoomPhotoRequest(RoomPhotoCreateWithIdDto RoomPhoto) : IRequest<AddRoomPhotoRequest.Response>
  {
    public const string RouteTemplate = "api/roomphotos/create";

    public record Response(Guid roomPhotoId);
  }
}
