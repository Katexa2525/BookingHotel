namespace Application.DTO.Food
{
  public class FoodDto
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid TypeFoodId { get; set; }
    public Guid HotelId { get; set; }
  }
}
