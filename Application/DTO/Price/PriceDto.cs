namespace Application.DTO.Price
{
  public class PriceDto
  {
    public Guid Id { get; set; }
    public Guid RoomId { get; set; }
    public Guid HotelId { get; set; }
    public Guid RoomTypeId { get; set; }
    public Guid CurrencyId { get; set; }
    public double DayPrice { get; set; }
  }
}
