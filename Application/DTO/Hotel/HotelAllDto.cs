namespace Application.DTO.Hotel
{
  public class HotelAllDto
  {
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public double Rating { get; set; }
    public int Star { get; set; }
    public string? MainPhoto { get; set; } = string.Empty;
  }
}
