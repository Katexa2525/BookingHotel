namespace Application.DTO.RoomPhoto
{
  public class RoomPhotoDto
  {
    public Guid Id { get; set; }
    public byte[] Photo { get; set; } = Array.Empty<byte>();
    public Guid RoomId { get; set; }
  }
}
