namespace Domain.Models
{
  public class RoomPhoto : BasePhotoEntity
  {
    public Guid RoomId { get; set; }
    public Room Room { get; set; } = null!;
  }
}
