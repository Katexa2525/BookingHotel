namespace Domain.Models
{
  public class Hotel : BaseEntity
  {
    public string Description { get; set; } = string.Empty;
    public string MainPhoto { get; set; } = string.Empty;
    public double Rating { get; set; }
    public string Location { get; set; } = string.Empty;
    public IEnumerable<Room> Rooms { get; set; } = Array.Empty<Room>();
    public IEnumerable<Food> Foods { get; set; } = Array.Empty<Food>();
    public IEnumerable<HotelFacility> HotelFacilities { get; set; } = Array.Empty<HotelFacility>();
    public IEnumerable<HotelPhoto> HotelPhotos { get; set; } = Array.Empty<HotelPhoto>();
    public IEnumerable<Location> Locations { get; set; } = Array.Empty<Location>();
    public IEnumerable<Price> Prices { get; set; } = Array.Empty<Price>();
  }
}
