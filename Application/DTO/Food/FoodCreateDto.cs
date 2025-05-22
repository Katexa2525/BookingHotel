namespace Application.DTO.Food
{
  public class FoodCreateDto
  {
    public Guid TypeFoodId { get; set; }
    public Guid HotelId { get; set; }
    public string Name { get; set; }
  }
}
