using MediatR;

namespace Application.DTO.Hotel.ClientRequest
{
  public record GetHotelsRequest : IRequest<GetHotelsRequest.Response>
  {
    public const string RouteTemplate = "/api/hotels";

    public record HotelAllDto(Guid Id, string Name, string Description, string Location, double Rating, int Star, string? MainPhoto);

    public record Response(IEnumerable<HotelAllDto> Hotels);
  }
}
 