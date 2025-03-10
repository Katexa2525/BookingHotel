namespace BookingHotel.Features.Home
{
  public class Hotel
  {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string MainPhoto { get; set; } = string.Empty;
    public double Rating { get; set; }
    public IEnumerable<HotelPhoto> HotelPhotos { get; set; } = Array.Empty<HotelPhoto>();
  }
}
