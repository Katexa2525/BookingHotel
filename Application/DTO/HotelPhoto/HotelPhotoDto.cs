namespace Application.DTO.HotelPhoto
{
  public class HotelPhotoDto
  {
    public Guid Id { get; set; }
    public byte[] Photo { get; set; }
    public Guid HotelId { get; set; }
  }
}
