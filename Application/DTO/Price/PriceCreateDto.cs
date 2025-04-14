namespace Application.DTO.Price
{
  public class PriceCreateDto
  {
    public Guid RoomId { get; set; }
    public Guid RoomTypeId { get; set; }
    public Guid CurrencyId { get; set; }
    public double DayPrice { get; set; }
  }
}
