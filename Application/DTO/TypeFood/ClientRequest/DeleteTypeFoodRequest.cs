using MediatR;

namespace Application.DTO.TypeFood.ClientRequest
{
  public record DeleteTypeFoodRequest(Guid typefoodId) : IRequest<DeleteTypeFoodRequest.Response>
  {
    public const string RouteTemplate = "api/typefoods/{typefoodId}";

    public record Response(bool IsSuccess);
  }
}
