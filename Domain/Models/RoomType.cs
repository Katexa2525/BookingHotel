namespace Domain.Models
{
  public class RoomType : BaseEntity
  {
    public ICollection<Price> Prices { get; set; }
    public ICollection<Room> Rooms { get; set; }
  }
}
