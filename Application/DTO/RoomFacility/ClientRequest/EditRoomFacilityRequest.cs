using MediatR;

namespace Application.DTO.RoomFacility.ClientRequest
{
  public record EditRoomFacilityRequest(RoomFacilityDto roomFacility) : IRequest<EditRoomFacilityRequest.Response>
  {
    public const string RouteTemplate = "api/roomfacilities/edit";
    public record Response(bool IsSuccess);
  }
}
