namespace Domain.Models
{
  public class RoomType : BaseEntity
  {
    public ICollection<Room> Rooms { get; set; }
  }
}
