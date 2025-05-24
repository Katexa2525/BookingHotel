using MediatR;

namespace Application.DTO.RoomFacility.ClientRequest
{
  public record AddRoomFacilityRequest(RoomFacilityCreateWithIdDto RoomFacility) : IRequest<AddRoomFacilityRequest.Response>
  {
    public const string RouteTemplate = "api/roomfacilities/create";

    public record Response(Guid roomFacilityId);
  }
}
