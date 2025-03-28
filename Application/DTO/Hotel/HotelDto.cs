namespace Application.DTO.Hotel
{
  public class HotelDto
  {
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public double Rating { get; set; }
    public int Star { get; set; }
  }
}
