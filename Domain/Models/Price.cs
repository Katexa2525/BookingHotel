namespace Domain.Models
{
  public class Price
  {
    public Guid Id { get; set; }
    public Guid RoomId { get; set; }
    public Room Room { get; set; }
    public Guid HotelId { get; set; }
    public Hotel Hotel { get; set; }
    public Guid RoomTypeId { get; set; }
    public RoomType RoomType { get; set; }
    public Guid CurrencyId { get; set; }
    public Currency Currency { get; set; }
    public double DayPrice { get; set; }
  }
}
