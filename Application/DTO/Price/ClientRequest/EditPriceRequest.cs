using MediatR;

namespace Application.DTO.Price.ClientRequest
{
  public record EditPriceRequest(PriceDto room) : IRequest<EditPriceRequest.Response>
  {
    public const string RouteTemplate = "api/prices/edit";
    public record Response(bool IsSuccess);
  }
}
