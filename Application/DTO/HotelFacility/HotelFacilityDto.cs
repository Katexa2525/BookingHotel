namespace Application.DTO.HotelFacility
{
  public class HotelFacilityDto
  {
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid HotelId { get; set; }
  }
}
