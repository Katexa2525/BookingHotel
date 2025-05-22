using Application.DTO.Room.ClientRequest;
using MediatR;

namespace Application.DTO.HotelFacility.ClientRequest
{
  public record GetHotelFacilitiesRequest(Guid hotelId) : IRequest<GetRoomsRequest.Response>
  {
    public const string RouteTemplate = "api/hotels/{hotelId}/facilities";

    public record Response(List<HotelFacilityDto>? Rooms);
  }
}
