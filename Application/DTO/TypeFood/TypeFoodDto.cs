using Application.DTO.Food;

namespace Application.DTO.TypeFood
{
  public class TypeFoodDto
  {
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<FoodDto> Foods { get; set; }
  }
}
