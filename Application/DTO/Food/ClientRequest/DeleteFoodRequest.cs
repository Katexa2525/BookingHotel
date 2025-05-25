using MediatR;

namespace Application.DTO.Food.ClientRequest
{
  public record DeleteFoodRequest(Guid foodId) : IRequest<DeleteFoodRequest.Response>
  {
    public const string RouteTemplate = "api/foods/{foodId}";

    public record Response(bool IsSuccess);
  }
}
