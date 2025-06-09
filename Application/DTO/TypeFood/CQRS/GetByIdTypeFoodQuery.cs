using MediatR;

namespace Application.DTO.TypeFood.CQRS
{
  public class GetByIdTypeFoodQuery : IRequest<TypeFoodDto>
  {
    public Guid Id { get; set; }
  }
}
