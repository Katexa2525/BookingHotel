using MediatR;

namespace Application.DTO.Food.CQRS
{
  public class GetAllFoodByHotelIdQuery : IRequest<List<FoodDto>>
  {
    public Guid HotelId { get; set; }
  }
}
