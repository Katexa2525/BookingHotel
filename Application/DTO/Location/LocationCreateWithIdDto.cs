namespace Application.DTO.Location
{
  public class LocationCreateWithIdDto
  {
    public string Name { get; set; } = string.Empty;
    public Guid HotelId { get; set; }
  }
}
