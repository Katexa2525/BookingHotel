using MediatR;

namespace Application.DTO.Food.ClientRequest
{
  public record EditFoodRequest(FoodDto food) : IRequest<EditFoodRequest.Response>
  {
    public const string RouteTemplate = "api/foods/edit";
    public record Response(bool IsSuccess);
  }
}
