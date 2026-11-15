namespace Application.DTO.HotelFacility
{
  public class HotelFacilityCreateWithIdDto
  {
    public string Name { get; set; } = string.Empty;
    public Guid HotelId { get; set; }
  }
}
