namespace Domain.Models
{
  public class Price
  {
    public Guid Id { get; set; }
    public Guid RoomId { get; set; }
    public Room Room { get; set; }
    public double DayPrice { get; set; }
  }
}
