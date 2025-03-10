namespace Domain.Models
{
  public class Hotel : BaseEntity
  {
    public string Description { get; set; }
    public double Rating { get; set; }
    public IEnumerable<Room> Rooms { get; set; }
    public IEnumerable<Food> Foods { get; set; }
    public IEnumerable<HotelFacility> HotelFacilities { get; set; }
    public IEnumerable<HotelPhoto> HotelPhotos { get; set; }
    public IEnumerable<Location> Locations { get; set; }
    public IEnumerable<Price> Prices { get; set; }
  }
}
