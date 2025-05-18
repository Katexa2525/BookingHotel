using MediatR;
using Microsoft.AspNetCore.Components.Forms;

namespace Application.DTO.Room.ClientRequest
{
  public record UploadRoomImageRequest(Guid RoomId, IBrowserFile File) : IRequest<UploadRoomImageRequest.Response>
  {
    //public const string RouteTemplate = "/api/hotels/{hotelId}/images";
    //public const string RouteTemplate = "api/hotels/{hotelId}/rooms/{roomId}/images";

    public const string RouteTemplate = "api/rooms/{roomId}/images";

    public record Response(string ImageName);
  }
}
