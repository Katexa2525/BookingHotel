using Application.DTO.Hotel.ClientRequest;
using MediatR;

namespace Application.DTO.Room.ClientRequest
{
  public record GetRoomsRequest : IRequest<GetRoomsRequest.Response>
  {
    public const string RouteTemplate = "api/rooms";

    public record Response(List<RoomAllDto> Rooms);
  }
}
