using Application.DTO.Booking;
using Application.DTO.Price;
using Application.DTO.RoomFacility;
using Application.DTO.RoomPhoto;
using Application.DTO.RoomType;

namespace Application.DTO.Room
{
  public class RoomDto
  {
    public Guid Id { get; set; }
    public Guid HotelId { get; set; }
    public int PeopleNumber { get; set; }
    public double Square { get; set; }
    /// <summary> Описание номера </summary>
    public string Description { get; set; } = string.Empty;
    public Guid RoomTypeId { get; set; }
    public IEnumerable<PriceDto>? Prices { get; set; }
    public IEnumerable<RoomPhotoDto>? RoomPhotos { get; set; }
    public IEnumerable<RoomFacilityDto>? RoomFacilities { get; set; }
    public RoomTypeDto? RoomType { get; set; }
    public IEnumerable<BookingDto>? Bookings { get; set; }
  }
}
