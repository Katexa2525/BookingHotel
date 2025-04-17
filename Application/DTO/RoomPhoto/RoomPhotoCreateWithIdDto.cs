namespace Application.DTO.RoomPhoto
{
  public class RoomPhotoCreateWithIdDto
  {
    public Guid RoomId { get; set; }
    public byte[] Photo { get; set; }
  }
}
