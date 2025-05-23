using MediatR;

namespace Application.DTO.Location.ClientRequest
{
  public record GetLocationsRequest(Guid hotelId) : IRequest<GetLocationsRequest.Response>
  {
    public const string RouteTemplate = "api/hotels/{hotelId}/locations";

    public record Response(List<LocationDto>? HotelFacilities);
  }
}
