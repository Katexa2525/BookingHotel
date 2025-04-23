using MediatR;

namespace Application.DTO.Food.CQRS
{
  public class UpdateFoodCommand : IRequest<Unit>
  {
    public FoodDto Dto { get; set; }
  }
}
