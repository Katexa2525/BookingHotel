namespace Application.DTO.Location
{
  public class LocationDto
  {
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid HotelId { get; set; }
  }
}
