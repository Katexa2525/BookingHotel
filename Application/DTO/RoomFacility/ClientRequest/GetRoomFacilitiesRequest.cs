using MediatR;

namespace Application.DTO.RoomFacility.ClientRequest
{
  public record GetRoomFacilitiesRequest(Guid roomId) : IRequest<GetRoomFacilitiesRequest.Response>
  {
    public const string RouteTemplate = "api/rooms/{roomId}/facilities";

    public record Response(List<RoomFacilityDto>? HotelFacilities);
  }
}
