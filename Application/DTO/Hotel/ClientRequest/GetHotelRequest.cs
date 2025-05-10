using MediatR;

namespace Application.DTO.Hotel.ClientRequest
{
  public record GetHotelRequest(Guid hotelId) : IRequest<GetHotelRequest.Response>
  {
    public const string RouteTemplate = "/api/hotels/{hotelId}";

    public record Response(HotelDto? Hotel);
  }
}
