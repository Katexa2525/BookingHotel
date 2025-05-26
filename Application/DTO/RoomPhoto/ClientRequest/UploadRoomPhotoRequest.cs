using MediatR;
using Microsoft.AspNetCore.Components.Forms;

namespace Application.DTO.RoomPhoto.ClientRequest
{
  public record UploadRoomPhotoRequest(Guid RoomId, IBrowserFile File) : IRequest<UploadRoomPhotoRequest.Response>
  {
    public const string RouteTemplate = "/api/rooms/{roomId}/images";

    public record Response(string ImageName);
  }
}
