using MediatR;

namespace Application.DTO.Price.ClientRequest
{
  public record DeletePriceRequest(Guid priceId) : IRequest<DeletePriceRequest.Response>
  {
    public const string RouteTemplate = "api/prices/{priceId}";

    public record Response(bool IsSuccess);
  }
}
