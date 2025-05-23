using MediatR;

namespace Application.DTO.Location.ClientRequest
{
  public record EditLocationRequest(LocationDto location) : IRequest<EditLocationRequest.Response>
  {
    public const string RouteTemplate = "api/location/edit";
    public record Response(bool IsSuccess);
  }
}
