using MediatR;

namespace Application.DTO.RoomType.ClientRequest
{
  public record GetRoomTypesRequest : IRequest<GetRoomTypesRequest.Response>
  {
    public const string RouteTemplate = "api/roomtypes";

    public record Response(List<RoomTypeAllDto>? RoomTypes);
  }
}
