using MediatR;

namespace Application.DTO.Food.CQRS
{
  public class GetAllFoodQuery : IRequest<List<FoodDto>>
  {
  }
}
