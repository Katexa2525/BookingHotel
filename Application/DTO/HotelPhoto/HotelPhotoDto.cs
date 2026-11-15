namespace Application.DTO.HotelPhoto
{
  public class HotelPhotoDto
  {
    public Guid Id { get; set; }
    public byte[] Photo { get; set; } = Array.Empty<byte>();
    public Guid HotelId { get; set; }
  }
}
