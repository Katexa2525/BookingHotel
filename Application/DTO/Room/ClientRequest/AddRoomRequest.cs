using MediatR;

namespace Application.DTO.Room.ClientRequest
{
  public record AddRoomRequest(RoomCreateDto Room) : IRequest<AddRoomRequest.Response>
  {
    public const string RouteTemplate = "api/rooms/create";

    public record Response(Guid roomId);
  }
}
