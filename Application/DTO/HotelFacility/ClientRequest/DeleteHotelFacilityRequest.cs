using MediatR;

namespace Application.DTO.HotelFacility.ClientRequest
{
  public record DeleteHotelFacilityRequest(Guid facilityId) : IRequest<DeleteHotelFacilityRequest.Response>
  {
    public const string RouteTemplate = "api/hotelfacilities/{facilityId}";

    public record Response(bool IsSuccess);
  }
}
