using MediatR;

namespace Application.DTO.Hotel.ClientRequest
{
  public record GetHotelsRequest : IRequest<GetHotelsRequest.Response>
  {
    public const string RouteTemplate = "/api/hotels";

    public record Response(IEnumerable<HotelAllDto> Hotels);
  }
}
 