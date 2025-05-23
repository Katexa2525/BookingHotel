using MediatR;

namespace Application.DTO.Location.ClientRequest
{
  public record DeleteLocationRequest(Guid locationId) : IRequest<DeleteLocationRequest.Response>
  {
    public const string RouteTemplate = "api/location/{locationId}";

    public record Response(bool IsSuccess);
  }
}
