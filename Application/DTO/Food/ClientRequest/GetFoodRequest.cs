using MediatR;

namespace Application.DTO.Food.ClientRequest
{
  public record GetFoodRequest(Guid foodId) : IRequest<GetFoodRequest.Response>
  {
    public const string RouteTemplate = "/api/foods/{foodId}";

    public record Response(FoodDto? Food);
  }
}
