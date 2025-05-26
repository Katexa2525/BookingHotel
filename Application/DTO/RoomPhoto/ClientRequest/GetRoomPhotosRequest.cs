using MediatR;

namespace Application.DTO.RoomPhoto.ClientRequest
{
  public record GetRoomPhotosRequest(Guid roomId) : IRequest<GetRoomPhotosRequest.Response>
  {
    public const string RouteTemplate = "api/rooms/{roomId}/photos";

    public record Response(List<RoomPhotoDto>? RoomPhotos);
  }
}
