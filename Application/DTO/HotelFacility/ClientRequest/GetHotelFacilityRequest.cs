using MediatR;

namespace Application.DTO.HotelFacility.ClientRequest
{
  public record GetHotelFacilityRequest(Guid hotelFacilityId) : IRequest<GetHotelFacilityRequest.Response>
  {
    public const string RouteTemplate = "/api/hotelfacilities/{facilityId}";

    public record Response(HotelFacilityDto? HotelFacility);
  }
}
