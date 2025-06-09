using MediatR;

namespace Application.DTO.TypeFood.CQRS
{
  public class GetAllTypeFoodQuery : IRequest<List<TypeFoodDto>>
  {
  }
}
