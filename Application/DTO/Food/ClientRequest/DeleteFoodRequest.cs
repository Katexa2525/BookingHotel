using MediatR;

namespace Application.DTO.Food.ClientRequest
{
  public record DeleteFoodRequest(Guid foodId) : IRequest<DeleteFoodRequest.Response>
  {
    public const string RouteTemplate = "api/hotelfoods/{foodId}";

    public record Response(bool IsSuccess);
  }
}
