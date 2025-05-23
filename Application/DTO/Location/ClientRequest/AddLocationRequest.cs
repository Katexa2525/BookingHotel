using MediatR;

namespace Application.DTO.Location.ClientRequest
{
  public record AddLocationRequest(LocationCreateWithIdDto Location) : IRequest<AddLocationRequest.Response>
  {
    public const string RouteTemplate = "api/location/create";

    public record Response(Guid locationId);
  }
}
