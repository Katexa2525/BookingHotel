using MediatR;

namespace Application.DTO.Room.ClientRequest
{
  public record EditRoomRequest(RoomDto room) : IRequest<EditRoomRequest.Response>
  {
    public const string RouteTemplate = "api/rooms/edit";
    public record Response(bool IsSuccess);
  }
}
