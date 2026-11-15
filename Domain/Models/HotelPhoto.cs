namespace Domain.Models
{
  public class HotelPhoto : BasePhotoEntity
  {
    public Guid HotelId { get; set; }
    public Hotel Hotel { get; set; } = null!;
  }
}
