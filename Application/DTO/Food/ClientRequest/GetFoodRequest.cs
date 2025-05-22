using MediatR;

namespace Application.DTO.Food.ClientRequest
{
  public record GetFoodRequest(Guid foodId) : IRequest<GetFoodRequest.Response>
  {
    public const string RouteTemplate = "/api/foods/{bookingId}";

    public record Response(FoodDto? Food);
  }
}
