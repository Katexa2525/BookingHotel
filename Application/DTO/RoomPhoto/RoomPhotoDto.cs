namespace Application.DTO.RoomPhoto
{
  public class RoomPhotoDto
  {
    public Guid Id { get; set; }
    public byte[] Photo { get; set; }
    public Guid RoomId { get; set; }
  }
}
