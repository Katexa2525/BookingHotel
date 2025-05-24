using MediatR;

namespace Application.DTO.RoomFacility.ClientRequest
{
  public record GetRoomFacilityRequest(Guid facilityId) : IRequest<GetRoomFacilityRequest.Response>
  {
    public const string RouteTemplate = "/api/roomfacilities/{facilityId}";

    public record Response(RoomFacilityDto? RoomFacility);
  }
}
