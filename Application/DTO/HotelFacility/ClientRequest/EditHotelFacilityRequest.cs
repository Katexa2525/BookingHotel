using MediatR;

namespace Application.DTO.HotelFacility.ClientRequest
{
  public record EditHotelFacilityRequest(HotelFacilityDto hotelFacility) : IRequest<EditHotelFacilityRequest.Response>
  {
    public const string RouteTemplate = "api/hotelfacilities/edit";
    public record Response(bool IsSuccess);
  }
}
