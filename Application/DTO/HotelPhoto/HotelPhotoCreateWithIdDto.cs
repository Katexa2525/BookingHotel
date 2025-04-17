namespace Application.DTO.HotelPhoto
{
  public class HotelPhotoCreateWithIdDto
  {
    public Guid HotelId { get; set; }
    public byte[] Photo { get; set; }
  }
}
