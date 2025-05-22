using MediatR;

namespace Application.DTO.Price.ClientRequest
{
  public record AddPriceRequest(PriceCreateDto Price) : IRequest<AddPriceRequest.Response>
  {
    public const string RouteTemplate = "api/prices/create";

    public record Response(Guid priceId);
  }
}
