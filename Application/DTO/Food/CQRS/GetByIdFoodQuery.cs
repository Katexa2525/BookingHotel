using MediatR;

namespace Application.DTO.Food.CQRS
{
  public class GetByIdFoodQuery : IRequest<FoodDto>
  {
    public Guid Id { get; set; }
  }
}
