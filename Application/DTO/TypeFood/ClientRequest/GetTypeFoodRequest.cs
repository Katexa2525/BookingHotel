using MediatR;

namespace Application.DTO.TypeFood.ClientRequest
{
  public record GetTypeFoodRequest(Guid typefoodId) : IRequest<GetTypeFoodRequest.Response>
  {
    public const string RouteTemplate = "/api/typefoods/{typefoodId}";

    public record Response(TypeFoodDto? Food);
  }
}
