using Application.DTO.Price;
using MediatR;

namespace Application.DTO.HotelFacility.ClientRequest
{
  public record AddHotelFacilityRequest(HotelFacilityCreateWithIdDto HotelFacility) : IRequest<AddHotelFacilityRequest.Response>
  {
    public const string RouteTemplate = "api/hotelfacilities/create";

    public record Response(Guid hotelFacilityId);
  }
}
