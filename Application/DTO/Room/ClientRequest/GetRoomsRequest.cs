using Application.DTO.Hotel.ClientRequest;
using MediatR;

namespace Application.DTO.Room.ClientRequest
{
  public record GetRoomsRequest(Guid hotelId) : IRequest<GetRoomsRequest.Response>
  {
    public const string RouteTemplate = "api/hotels/{hotelId}/rooms";

    public record Response(List<RoomDto>? Rooms);
  }
}
