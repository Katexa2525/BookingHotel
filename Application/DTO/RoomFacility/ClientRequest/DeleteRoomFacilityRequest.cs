using MediatR;

namespace Application.DTO.RoomFacility.ClientRequest
{
  public record DeleteRoomFacilityRequest(Guid facilityId) : IRequest<DeleteRoomFacilityRequest.Response>
  {
    public const string RouteTemplate = "api/roomfacilities/{facilityId}";

    public record Response(bool IsSuccess);
  }
}
