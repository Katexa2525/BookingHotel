using MediatR;

namespace Application.DTO.Price.ClientRequest
{
  public record GetPricesRequest(Guid roomId) : IRequest<GetPricesRequest.Response>
  {
    public const string RouteTemplate = "api/rooms/{roomId}/prices";

    public record Response(List<PriceDto>? Prices);
  }
}
