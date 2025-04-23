using MediatR;

namespace Application.DTO.Food.CQRS
{
  public class CreateFoodCommand: IRequest<Guid>
  {
    public FoodCreateWithIdDto Dto { get; set; }
  }
}
