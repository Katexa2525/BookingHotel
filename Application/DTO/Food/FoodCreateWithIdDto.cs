namespace Application.DTO.Food
{
  public class FoodCreateWithIdDto
  {
    public string Name { get; set; } = string.Empty;
    public Guid TypeFoodId { get; set; }
    public Guid HotelId { get; set; }
  }
}
