using MediatR;

namespace Application.DTO.Location.ClientRequest
{
  public record GetLocationRequest(Guid locationId) : IRequest<GetLocationRequest.Response>
  {
    public const string RouteTemplate = "/api/locations/{locationId}";

    public record Response(LocationDto? Location);
  }
}
