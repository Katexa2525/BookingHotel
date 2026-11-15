using MediatR;

namespace Application.DTO.Hotel.ClientRequest
{
  public record GetHotelsRequest : IRequest<HotelListPageDto?>
  {
    public const string RouteTemplate = "api/hotels";

    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 20;
    public string? SearchTerm { get; init; }
    public double? MinRating { get; init; }
    public double? MaxRating { get; init; }
  }
}
 