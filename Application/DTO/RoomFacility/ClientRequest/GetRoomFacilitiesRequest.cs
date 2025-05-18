using MediatR;

namespace Application.DTO.RoomFacility.ClientRequest
{
  public record GetRoomFacilitiesRequest : IRequest<GetRoomFacilitiesRequest.Response>
  {
    public const string RouteTemplate = "api/roomFacility";

    public record Response(List<RoomFacilityDto>? Facilities);
  }
}
