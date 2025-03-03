namespace Domain.Models
{
  public abstract class RoomRelatedEntity : BaseEntity
  {
    public Guid RoomId { get; set; }
    public Room Room { get; set; }
  }
}
