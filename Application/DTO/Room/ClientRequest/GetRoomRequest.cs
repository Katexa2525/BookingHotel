using MediatR;

namespace Application.DTO.Room.ClientRequest
{
  public record GetRoomRequest(Guid roomId) : IRequest<GetRoomRequest.Response>
  {
    public const string RouteTemplate = "/api/rooms/{roomId}";

    public record Response(RoomDto? Room);
  }
}
