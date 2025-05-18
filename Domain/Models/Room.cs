namespace Domain.Models
{
  public class Room
  {
    public Guid Id { get; set; }
    public Guid HotelId { get; set; }
    public Hotel Hotel { get; set; }
    public int PeopleNumber { get; set; }
    public double Square { get; set; }
    /// <summary> Основное фото отеля </summary>
    public string? MainPhoto { get; set; } = string.Empty;
    /// <summary> Описание номера </summary>
    public string? Description { get; set; } = string.Empty;
    public ICollection<Price>? Prices { get; set; }
    public ICollection<RoomPhoto>? RoomPhotos { get; set; }
    public ICollection<RoomFacility>? RoomFacilities { get; set; }
    public Guid RoomTypeId { get; set; }
    public RoomType RoomType { get; set; }
    public ICollection<Booking>? Bookings { get; set; }
  }
}
