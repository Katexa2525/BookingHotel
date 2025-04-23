using MediatR;

namespace Application.DTO.Food.CQRS
{
  public class DeleteFoodCommand : IRequest<Unit>
  {
    public Guid FoodId { get; set; }
  }
}
