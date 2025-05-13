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
    /// <summary>Время заезда в часах, например, с 14:00  </summary>
    public string Arrival { get; set; } = string.Empty;
    /// <summary>Время выезда в часах, например, до 12:00  </summary>
    public string Departure { get; set; } = string.Empty;
  }
}
