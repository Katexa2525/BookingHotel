using Application.DTO.Food;
using Application.DTO.HotelFacility;
using Application.DTO.HotelPhoto;
using Application.DTO.Location;
using Application.DTO.Review;
using Application.DTO.Room;
using Domain.Models;

namespace Application.DTO.Hotel
{
  public class HotelUpdateDto
  {
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public double Rating { get; set; }
    public int Star { get; set; }
    public string? MainPhoto { get; set; }
    /// <summary>Время заезда в часах, например, с 14:00  </summary>
    public string Arrival { get; set; } = string.Empty;
    /// <summary>Время выезда в часах, например, до 12:00  </summary>
    public string Departure { get; set; } = string.Empty;
    /// <summary>Широта </summary>
    public double Latitude { get; set; }
    /// <summary>Долгота </summary>
    public double Longitude { get; set; }
    public IEnumerable<RoomUpdateDto>? Rooms { get; set; }
    public IEnumerable<FoodDto>? Foods { get; set; }
    public IEnumerable<HotelFacilityDto>? HotelFacilities { get; set; }
    public IEnumerable<HotelPhotoDto>? HotelPhotos { get; set; }
    public IEnumerable<LocationDto>? Locations { get; set; }
    public IEnumerable<ReviewDto>? Reviews { get; set; }
    public HotelUsefulInfo? HotelUsefulInfo { get; set; }
  }
}
