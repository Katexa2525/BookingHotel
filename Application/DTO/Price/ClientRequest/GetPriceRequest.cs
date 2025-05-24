using MediatR;

namespace Application.DTO.Price.ClientRequest
{
  public record GetPriceRequest(Guid priceId) : IRequest<GetPriceRequest.Response>
  {
    public const string RouteTemplate = "api/prices/{priceId}";

    public record Response(PriceDto? Price);
  }
}
