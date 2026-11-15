namespace Application.DTO.Hotel
{
  public class HotelListDto
  {
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public double Rating { get; set; }
    public int Star { get; set; }
    public string? MainPhoto { get; set; }
    public string Arrival { get; set; } = string.Empty;
    public string Departure { get; set; } = string.Empty;
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public List<string> FacilityNames { get; set; } = new();
    public List<string> FoodNames { get; set; } = new();
    public List<string> NearbyLocationNames { get; set; } = new();
  }
}
