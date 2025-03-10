namespace Domain.Models
{
  public class Room
  {
    public Guid Id { get; set; }
    public Guid HotelId { get; set; }
    public Hotel Hotel { get; set; }
    public int PeopleNumber { get; set; }
    public double Square { get; set; }
    public IEnumerable<Price> Prices { get; set; }
    public IEnumerable<RoomPhoto> RoomPhotos { get; set; }
    public IEnumerable<RoomFacility> RoomFacilities { get; set; }
    public Guid RoomTypeId { get; set; }
    public RoomType RoomType { get; set; }
  }
}
